using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=>c.Id);

            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(150)");

            //1:N=> Category:Expenses
            builder.HasMany(c => c.Expenses).WithOne(b => b.Category).HasForeignKey(b => b.CategoryId);

            builder.ToTable("Categories");
        }
    }
}
