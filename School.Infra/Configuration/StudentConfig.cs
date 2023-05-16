using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Aggregates.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FinalGrade).IsRequired(false);

            builder.Property(s => s.FirstName)
                .HasMaxLength(50);

            builder.Property(s => s.LastName)
                .HasMaxLength(100);

            builder.Property(s => s.Phone)
                .HasMaxLength(11); 
        }
    }
}
