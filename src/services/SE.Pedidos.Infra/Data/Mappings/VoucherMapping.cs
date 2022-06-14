using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Pedidos.Domain;

namespace SE.Pedidos.Infra.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Vouchers");
        }
    }

}
