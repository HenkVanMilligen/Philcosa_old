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
    public class PostcardValueConfiguration : IEntityTypeConfiguration<PostcardValue>
    {
        public void Configure(EntityTypeBuilder<PostcardValue> builder)
        {
            builder.HasData(                   
                    new PostcardValue
                    {
                        Id = 1,
                        Code = "$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 0,
                        MaxValue = 5
                    },
                    new PostcardValue
                    {
                        Id = 2,
                        Code = "$$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 5.01m,
                        MaxValue = 15
                    },
                    new PostcardValue
                    {
                        Id = 3,
                        Code = "$$$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 15.01m,
                        MaxValue = 50
                    },
                    new PostcardValue
                    {
                        Id = 4,
                        Code = "$$$$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 50.01m,
                        MaxValue = 150
                    },
                    new PostcardValue
                    {
                        Id = 5,
                        Code = "$$$$$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 150.01m,
                        MaxValue = 500
                    },
                    new PostcardValue
                    {
                        Id = 6,
                        Code = "$$$$$$",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        MinValue = 500.01m,
                        MaxValue = null
                    }
                );
        }
    }
}
