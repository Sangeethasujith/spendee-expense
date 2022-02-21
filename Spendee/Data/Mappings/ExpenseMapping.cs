using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spendee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spendee.Data.Mappings
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(c => c.Value).IsRequired();
            builder.Property(c => c.PaymentType).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.CategoryId).IsRequired();
            builder.ToTable("Expenses");
        }
    }
}
