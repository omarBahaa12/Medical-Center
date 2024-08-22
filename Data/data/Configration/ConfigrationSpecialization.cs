using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationSpecialization : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {

            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();


            builder.ToTable("Specializations");

            builder.Property(s => s.SpecializationName).HasColumnType("nvarchar").HasMaxLength(30);
            builder.Property(s => s.SpecializationName).IsRequired();

            builder.HasData(LoadSpecialization());
        }

        private static List<Specialization> LoadSpecialization()
        {
            //1   surgery
            //2   Pediatrics
            //3   Obstetrics and gynecology
            //4   Internal medicine
            //5   Orthopedics
            //6   Ear - nose medicine
            //7   ophthalmology
            //8   Neurology
            return new List<Specialization>
            {
                new Specialization{ID=1, SpecializationName ="surgery"},
                new Specialization{ID=2,SpecializationName ="Pediatrics"},
                new Specialization{ID=3,SpecializationName ="Obstetrics and gynecology"},
                new Specialization{ID=4,SpecializationName ="Internal medicine"},
                new Specialization{ID=5,SpecializationName ="Orthopedics"},
                new Specialization{ID=6,SpecializationName ="Ear - nose medicine"},
                new Specialization{ID=7,SpecializationName ="ophthalmology"},
                new Specialization{ID=8,SpecializationName ="Neurology"}

            };
        }
    }
}
