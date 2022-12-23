using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Features.Assignments.Models;
using SchoolApplication.Features.Assignments.Views;

namespace SchoolApplication.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();
        
    public AssignmentsController() {}

    [HttpPost]
    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel
        {
            ID = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };
        
        _mockDb.Add(assignment);

        return new AssignmentResponse
        {
            ID = assignment.ID,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentResponse
            {
                ID = assignment.ID,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            }).ToList();
    }

    [HttpGet("{id}")]
    public AssignmentResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is null)
        {
            return null;
        }

        return new AssignmentResponse
        {
            ID = assignment.ID,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpDelete("{id}")]
    public void Remove([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is not null)
        {
            _mockDb.Remove(assignment);
        }
    }

    [HttpPatch("{id}")]
    public void Update([FromRoute] string id, AssignmentRequest request)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is not null)
        {
            foreach (var x in _mockDb)
            {
                if (x == assignment)
                {
                    x.Updated = DateTime.UtcNow;
                    x.Subject = request.Subject;
                    x.Description = request.Description;
                    x.Deadline = request.Deadline;
                }
            }
        }
    }
}