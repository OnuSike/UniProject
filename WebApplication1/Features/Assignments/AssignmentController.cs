using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Assignments.Models;
using WebApplication1.Features.Assignments.Views;

namespace WebApplication1.Features.Assignments;

[ApiController]
[Route("assignments")]
public class AssignmentController
{
    private static List<AssignmentModel> _mockDd = new List<AssignmentModel>();

    public AssignmentController() {}

    [HttpPost]
    public AssignmentResponse Add(AssignmentsRequest request)
    {
        var assignment = new AssignmentModel
        {
            ID = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            subject = request.subject,
            descriere = request.descriere,
            DeadLine = request.DeadLine
        };

        _mockDd.Add(assignment);

        return new AssignmentResponse
        {
            ID = assignment.ID,
            subject = assignment.subject,
            DeadLine = assignment.DeadLine,
            descriere = assignment.descriere
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDb.Select(
            assignment => new AssignmentResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            }).ToList();
    }

    [HttpGet("ID")]
    public AssignmentResponse Get([FromRoute] string ID)
    {
        var assignment = _mockDd.FirstOrDefault(x => x.ID == ID);
        if (assignment is null)
        {
            return null;
        }
        
        return new AssignmentResponse
        {
            ID = assignment.ID,
            subject = assignment.subject,
            DeadLine = assignment.DeadLine,
            descriere = assignment.descriere
        };
    }
    // Tema
    // [HttpDelete] - dupa id
    // [HttpPatch] - id cel vechi, date noi pentru cel nou
}