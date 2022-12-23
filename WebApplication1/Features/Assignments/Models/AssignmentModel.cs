using System.ComponentModel.DataAnnotations;
using WebApplication1.Base;

namespace WebApplication1.Features.Assignments.Models;

public class AssignmentModel : Base.Model
{
    public string subject { get; set; }
    
    public string descriere { get; set; }
    
    public DateTime DeadLine { get; set; }
}