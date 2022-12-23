using SchoolApplication.Base;

namespace SchoolApplication.Features.Tests.Models;

public class TestModel : Model
{
    public string Subject { get; set; }
    
    public DateTime TestDate { get; set; }
}