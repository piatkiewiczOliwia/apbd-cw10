using cw10.Models;

namespace cw10.DTOs;

public class PatientWithPrescriptionsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public ICollection<PrescriptionGETDto> PrescriptionGetDtos { get; set; }
}

public class PrescriptionGETDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<PrescriptionMedicamentGETDto> Medicaments { get; set; } 
    public DoctorGETDto Doctor { get; set; }
}

public class PrescriptionMedicamentGETDto
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Details { get; set; }
}

public class DoctorGETDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
