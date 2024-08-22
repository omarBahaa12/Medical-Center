
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentStatus> AppointmentsStatus { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public static string GetConnectionstring()
        {
            return new ConfigurationBuilder().SetBasePath("D:\\Projects\\ClinicApp\\Data\\data\\appsetting.json")
                .AddJsonFile("appsetting.json").Build()
            .GetSection("ConnectionString").Value!;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer("Server = .;Database = Clinic; User Id=sa;Password = sa123456;TrustServerCertificate = true;")
                ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
