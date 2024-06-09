using cw10.Models;

namespace cw10.DTOs;

public class PrescriptionDto
{
    //public int IdPrescription { get; set; }
    public PatientDto Patient { get; set; }
    public ICollection<PrescriptionMedicamentDto> Medicaments { get; set; } 
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
    
}