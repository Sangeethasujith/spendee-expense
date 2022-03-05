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
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(e => e.Value).IsRequired();
            builder.Property(e => e.PaymentType).IsRequired().HasColumnType("varchar(50)");
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.CategoryId).IsRequired();
            builder.ToTable("Expenses");
        }
    }
}
