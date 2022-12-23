using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Features.Assignments.Views;

public class AssignmentsRequest
{
    [Required]public string subject { get; set; }
    
    [Required]public string descriere { get; set; }
    
    [Required]public DateTime DeadLine { get; set; }
}