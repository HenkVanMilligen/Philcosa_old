using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Configuration
{
    public class IssuedByEntityConfiguration : IEntityTypeConfiguration<IssuedByEntity>
    {
        public void Configure(EntityTypeBuilder<IssuedByEntity> builder)
        {
            string seedFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Philcosa.Infrastructure.Persistence\\Seeds\\";
            string file = Path.Combine(seedFolder, "IssuedByEntities.csv");

            var dictionary = new List<string>();
            using (var rd = new StreamReader(file))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    //string clean is done with Regex
                    dictionary.Add(Regex.Replace(splits[0], "[^A-Za-z0-9() ]", ""));
                }
            }

            var id = 1;
            var list = new List<IssuedByEntity>();
            foreach(var entity in dictionary)
            {
                if (String.IsNullOrEmpty(entity))
                    continue;

                //string code;
                //if (entity.Contains('('))
                //{
                //    code = entity.Split().Where(x => x.StartsWith("(") && x.EndsWith(")")).SingleOrDefault().ToUpper();
                //    entity.Remove()
                //}
                //else
                //{
                //    code = string.Join("", entity.Split(' ').Select(s => s[0].ToString().ToUpper()));
                //}

                list.Add(new IssuedByEntity
                {
                    Id = id++,
                    CreatedBy = "DataSeed",
                    Created = DateTime.Now,
                    LastModifiedBy = null,
                    LastModified = null,
                    Code = null,
                    Name = entity
                });


            }
            builder.HasData(list);
        }
    }
}
