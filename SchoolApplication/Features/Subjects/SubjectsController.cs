using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Features.Subjects.Models;
using SchoolApplication.Features.Subjects.Views;

namespace SchoolApplication.Features.Subjects;

[ApiController]
[Route("subjects")]
public class SubjectsController
{
    private static List<SubjectModel> _mockDb = new List<SubjectModel>();
        
    public SubjectsController() {}
    
    [HttpPost]
    public SubjectResponse Add(SubjectRequest request)
    {
        var assignment = new SubjectModel
        {
            ID = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };
        
        _mockDb.Add(assignment);

        return new SubjectResponse
        {
            ID = assignment.ID,
            Name = assignment.Name,
            ProfessorMail = assignment.ProfessorMail,
            Grades = assignment.Grades
        };
    }
    
    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDb.Select(
            assignment => new SubjectResponse
            {
                ID = assignment.ID,
                Name = assignment.Name,
                ProfessorMail = assignment.ProfessorMail,
                Grades = assignment.Grades
            }).ToList();
    }
    
    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is null)
        {
            return null;
        }

        return new SubjectResponse
        {
            ID = assignment.ID,
            Name = assignment.Name,
            ProfessorMail = assignment.ProfessorMail,
            Grades = assignment.Grades
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
    public void Update([FromRoute] string id, SubjectRequest request)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is not null)
        {
            foreach (var x in _mockDb)
            {
                if (x == assignment)
                {
                    x.Updated = DateTime.UtcNow;
                    x.Name = request.Name;
                    x.ProfessorMail = request.ProfessorMail;
                    x.Grades = request.Grades;
                }
            }
        }
    }
}