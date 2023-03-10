using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Features.Tests.Views;

public class TestRequest
{
    [Required]public string Subject { get; set; }
    
    [Required]public DateTime TestDate { get; set; }
}