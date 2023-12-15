using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlayerCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Kalem1",
                Price = 20,
                Stock=20,
                CreateDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                CategoryId = 2,
                Name ="Kitap1",
                Stock = 30,
                Price = 200,
                CreateDate = DateTime.Now,
            },
             new Product
             {
                 Id = 3,
                 CategoryId = 2,
                 Name = "Kitap2",
                 Stock = 30,
                 Price = 600,
                 CreateDate = DateTime.Now,
             },
             new Product
             {
                 Id = 4,
                 CategoryId = 2,
                 Name = "kitap3",
                 Stock = 30,
                 Price = 320,
                 CreateDate = DateTime.Now,
             }
            );
            
        }
    }
}
