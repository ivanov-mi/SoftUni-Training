namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity => 
            {
                entity
                    .Property(p => p.FirstName)
                    .IsUnicode(true);

                entity
                    .Property(p => p.LastName)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Address)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Email)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitation>(entity => 
            {
                entity
                    .Property(v => v.Comments)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Diagnose>(entity => 
            {
                entity
                    .Property(d => d.Name)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Comments)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(entity => 
            {
                entity
                    .Property(m => m.Name)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity
                    .HasKey(pm => new { pm.MedicamentId, pm.PatientId});
            });

            modelBuilder.Entity<Doctor>(entity => 
            {
                entity
                    .Property(d => d.Name)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Specialty)
                    .IsUnicode(true);
            });
        }
    }
}
