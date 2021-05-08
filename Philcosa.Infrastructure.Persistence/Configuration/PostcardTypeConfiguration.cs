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
    public class PostcardTypeConfiguration : IEntityTypeConfiguration<PostcardType>
    {
        public void Configure(EntityTypeBuilder<PostcardType> builder)
        {
            builder.HasData(
                    new PostcardType
                    {
                        Id = 1,
                        Code = "FDC",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "First Day"
                    },
                    new PostcardType
                    {
                        Id = 2,
                        Code = "CMC",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Comemorative"
                    },
                    new PostcardType
                    {
                        Id = 3,
                        Code = "FLT",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Flight"
                    },
                    new PostcardType
                    {
                        Id = 4,
                        Code = "SLK",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Silk"
                    },
                    new PostcardType
                    {
                        Id = 5,
                        Code = "GLD",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Gold Foiled"
                    },
                    new PostcardType
                    {
                        Id = 6,
                        Code = "MIL",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Military"
                    },
                    new PostcardType
                    {
                        Id = 7,
                        Code = "FIL",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Filatelic"
                    },
                    new PostcardType
                    {
                        Id = 8,
                        Code = "BAL",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Balloon"
                    },
                    new PostcardType
                    {
                        Id = 9,
                        Code = "RWY",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Railway"
                    }
                );
        }
    }
}
