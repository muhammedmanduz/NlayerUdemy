using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlayerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Configurations
{
    public class ProductFeatureConfıguration : IEntityTypeConfiguration<ProductFeaure>
    {
        public void Configure(EntityTypeBuilder<ProductFeaure> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithOne(x=>x.ProductFeaure).HasForeignKey<ProductFeaure>(x=>x.ProductId);
           

            //builder.ToTable("ProductFeatures");



        }
    }
}
