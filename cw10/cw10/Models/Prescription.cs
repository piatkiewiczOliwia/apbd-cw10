using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw10.Models;

[Table("prescriptions")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))] public Patient Patient { get; set; } = null!;
    
    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))] public Doctor Doctor { get; set; } = null!;

    public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } =
        new HashSet<Prescription_Medicament>();
}