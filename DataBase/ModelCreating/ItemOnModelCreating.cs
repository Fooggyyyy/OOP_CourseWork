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
    internal class ItemOnModelCreating : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.Property(e => e.Size).IsRequired();
            entity.Property(e => e.Color).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.PhotoPath).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Rating).HasDefaultValue(0.0);

        }
    }
}
