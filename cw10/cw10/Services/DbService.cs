using cw10.Data;
using cw10.DTOs;
using cw10.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace cw10.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<PrescriptionDto> AddPrescription(PrescriptionDto prescriptionDto)
    {
        if (!await DoesPatientExists(prescriptionDto.Patient))
        {
            var newPatient = new Patient()
            {
                FirstName = prescriptionDto.Patient.FirstName,
                LastName = prescriptionDto.Patient.LastName,
                Birthdate = prescriptionDto.Patient.Birthdate
            };
            await _context.AddAsync(newPatient);
            await _context.SaveChangesAsync();
        }

        foreach (var medicament in prescriptionDto.Medicaments)
        {
            if (! await DoesMedicamentExists(medicament))
            {
                throw new Exception("Medicament does not exist.");
            }
            
        }

        int medsCount = prescriptionDto.Medicaments.Count();
        if (medsCount > 10)
        {
            throw new Exception("Prescription can't have more than 10 medicaments");
        }

        if (prescriptionDto.DueDate < prescriptionDto.Date)
        {
            throw new Exception("Prescription has invalid due date");
        }

        Prescription prescription = new Prescription()
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdPatient = prescriptionDto.Patient.IdPatient,
            IdDoctor = prescriptionDto.IdDoctor
        };
        
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();

        foreach (var med in prescriptionDto.Medicaments)
        {
            Prescription_Medicament prescriptionMedicament = new Prescription_Medicament()
            {
                IdMedicament =med.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Dose = med.Dose,
                Details = med.Details
            };
            
            await _context.AddAsync(prescriptionMedicament);
            await _context.SaveChangesAsync();
        }

        return prescriptionDto;
    }

    public async Task<bool> DoesPatientExists(PatientDto patient)
    {
        return await _context.Patients.AnyAsync(p => p.IdPatient == patient.IdPatient);
    }

    public async Task<bool> DoesMedicamentExists(PrescriptionMedicamentDto medicament)
    {
        return await _context.Medicaments.AnyAsync(m => m.IdMedicament == medicament.IdMedicament);
    }

    public async Task<PatientWithPrescriptionsDto> GetPatientWithData(int idPatient)
    {
        bool patientExists = await _context.Patients.AnyAsync(p => p.IdPatient == idPatient);

        if (!patientExists)
        {
            throw new Exception("Patient with given id does not exists");
        }

        var resPatient = await _context.Patients
            .Where(p => p.IdPatient == idPatient)
            .Select(p => new PatientWithPrescriptionsDto()
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate,
                PrescriptionGetDtos = p.Prescriptions
                    .Select(pr => new PrescriptionGETDto()
                    {
                        IdPrescription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Medicaments = pr.Prescription_Medicaments
                            .Select(m => new PrescriptionMedicamentGETDto()
                            {
                                IdMedicament = m.IdMedicament,
                                Details = m.Details,
                                Dose = m.Dose
                            }).ToList(),
                        Doctor = new DoctorGETDto()
                        {
                            IdDoctor = pr.Doctor.IdDoctor,
                            FirstName = pr.Doctor.FirstName,
                            LastName = pr.Doctor.LastName,
                            Email = pr.Doctor.Email
                        }
                    })
                    .OrderBy(pr => pr.DueDate)
                    .ToList()
            }).FirstOrDefaultAsync();

        return resPatient!;
    }
}