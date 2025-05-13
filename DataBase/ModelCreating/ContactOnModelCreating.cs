using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseWork.DataBase.ModelCreating
{
    internal class ContactOnModelCreating : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.HasKey(e => e.Id); 

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100); 

            entity.Property(e => e.Description)
                .HasMaxLength(500); 

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
