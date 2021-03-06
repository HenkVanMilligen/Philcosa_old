using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                    new Country
                    {
                        Id = 1,
                        Code = "VEN",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Venda"
                    },
                    new Country
                    {
                        Id = 2,
                        Code = "TRA",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Transkei"
                    },
                    new Country
                    {
                        Id = 3,
                        Code = "CIS",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Ciskei"
                    },
                    new Country
                    {
                        Id = 4,
                        Code = "BOP",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Bophuthatswana"
                    },
                    new Country
                    {
                        Id = 5,
                        Code = "SWA",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "South West Africa"
                    },
                    new Country
                    {
                        Id = 6,
                        Code = "RSA",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "South Africa"
                    },
                    new Country
                    {
                        Id = 7,
                        Code = "NAM",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Namibia"
                    }
                );
        }
    }
}
