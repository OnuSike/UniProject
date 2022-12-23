using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Features.Tests.Models;
using SchoolApplication.Features.Tests.Views;

namespace SchoolApplication.Features.Tests;

[ApiController]
[Route("tests")]
public class TestsController
{
    private static List<TestModel> _mockDb = new List<TestModel>();
        
    public TestsController() {}
    
    [HttpPost]
    public TestResponse Add(TestRequest request)
    {
        var assignment = new TestModel
        {
            ID = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            TestDate = request.TestDate
        };
        
        _mockDb.Add(assignment);

        return new TestResponse
        {
            ID = assignment.ID,
            Subject = assignment.Subject,
            TestDate = assignment.TestDate
        };
    }
    
    [HttpGet]
    public IEnumerable<TestResponse> Get()
    {
        return _mockDb.Select(
            assignment => new TestResponse
            {
                ID = assignment.ID,
                Subject = assignment.Subject,
                TestDate = assignment.TestDate
            }).ToList();
    }
    
    [HttpGet("{id}")]
    public TestResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x => x.ID == id);
        if (assignment is null)
        {
            return null;
        }

        return new TestResponse
        {
            ID = assignment.ID,
            Subject = assignment.Subject,
            TestDate = assignment.TestDate
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
    public void Update([FromRoute] string id, TestRequest request)
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
                    x.TestDate = request.TestDate;
                }
            }
        }
    }
}