using cw10.DTOs;
using cw10.Models;

namespace cw10.Services;

public interface IDbService
{
    Task<PrescriptionDto> AddPrescription(PrescriptionDto prescriptionDto);
    Task<bool> DoesPatientExists(PatientDto patient);
    Task<bool> DoesMedicamentExists(PrescriptionMedicamentDto medicament);

    Task<PatientWithPrescriptionsDto> GetPatientWithData(int idPatient);

}