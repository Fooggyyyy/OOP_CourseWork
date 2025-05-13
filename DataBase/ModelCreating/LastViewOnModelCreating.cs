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
    internal class LastViewOnModelCreating : IEntityTypeConfiguration<LastView>
    {
        public void Configure(EntityTypeBuilder<LastView> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TimeView).IsRequired();

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
