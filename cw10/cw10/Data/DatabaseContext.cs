using cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace cw10.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new() { IdDoctor = 1, FirstName = "Bob", LastName = "Jobs", Email = "bobek@hotmail.com"},
            new() {IdDoctor = 2, FirstName = "Alice", LastName = "Stewart", Email = "alice123@hotmail.com"}
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new() {IdMedicament = 1, Name = "Velaxin", Description = "fdkujb", Type = "antidepressant"},
            new() {IdMedicament = 2, Name = "Apap", Description = "fdkufdgjb", Type = "pain killer"}
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new() {IdPatient = 1, FirstName = "Pep", LastName = "Trol", Birthdate = DateTime.Now}
        });
        
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new() {IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 1, IdDoctor = 2}
        });
        
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
        {
            new() {IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "bwdfieriuwfo"}
        });
        
        
    }

}