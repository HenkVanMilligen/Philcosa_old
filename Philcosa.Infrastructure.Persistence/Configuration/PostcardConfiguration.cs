using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Philcosa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Configuration
{
    public class PostcardConfiguration : IEntityTypeConfiguration<Postcard>
    {
        public void Configure(EntityTypeBuilder<Postcard> builder)
        {
            //string seedFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Philcosa.Infrastructure.Persistence\\Seeds\\";

            ////countries 
            //var countries = GetCountries();

            //// issued by entitues
            //var issuedByEntities = GetIssuedByEntities(seedFolder);

            ////themes
            //var themes = GetThemes(seedFolder);

            ////postcard types
            //var types = GetPostcardTypes(seedFolder);

            ////postcard values 
            //var values = GetPostcardValues(seedFolder);

            //// postcards
            //var postCards = GetPostcards(seedFolder, countries, issuedByEntities, themes, types, values);           
          
            //builder.HasData(postCards);
        }

        private List<Postcard> GetPostcards(string seedFolder, List<Country> countries, List<IssuedByEntity> issuedByEntities, List<Theme> themes, List<PostcardType> types, List<PostcardValue> values)
        {
            string file = Path.Combine(seedFolder, "Postcards.csv");

            var records = new List<Postcard>();
            using (var rd = new StreamReader(file))
            {
                using var csv = new CsvReader(rd, CultureInfo.InvariantCulture);
                csv.Read();
                csv.ReadHeader();
                var id = 1;
                while (csv.Read())
                {
                    var dateWithId = csv.GetField<string>("Date");
                    var dates = dateWithId.Split(".");
                    var date = DateTime.ParseExact(dates[0], "yyyyMMdd", CultureInfo.InvariantCulture);
                    var numberOnDate = dates[1];

                    var themesList = new List<Theme>();
                    var theme1 = csv.GetField<string>("Theme A");
                    if (!string.IsNullOrEmpty(theme1))
                        themesList.Add(themes.SingleOrDefault(x => x.Name == theme1));

                    var theme2 = csv.GetField<string>("Theme B");
                    if (!string.IsNullOrEmpty(theme2))
                        themesList.Add(themes.SingleOrDefault(x => x.Name == theme2));

                    var theme3 = csv.GetField<string>("Theme C");
                    if (!string.IsNullOrEmpty(theme3))
                        themesList.Add(themes.SingleOrDefault(x => x.Name == theme3));

                    var theme4 = csv.GetField<string>("Theme D");
                    if (!string.IsNullOrEmpty(theme4))
                        themesList.Add(themes.SingleOrDefault(x => x.Name == theme4));

                    var areaFromCSV = csv.GetField<string>("Area");
                    var typeFromCSV = csv.GetField<string>("Type");
                    var issuedByFromCSV = csv.GetField<string>("Issued By");
                    var noFromCSV = csv.GetField<string>("No");
                    var valueFromCSV = csv.GetField<string>("Value");
                    var descFromCSV = csv.GetField<string>("Description");
                    var noIssuedFromCSV = csv.GetField<string>("# Issued").Trim();
                    var atlasFromCSV = csv.GetField<string>("Atlas");
                    var albertaFromCSV = csv.GetField<string>("Alberta");

                    Int32.TryParse(noIssuedFromCSV, out int j);
                    var record = new Postcard
                    {
                        Id = id++,
                        CreatedBy = "DataSeed",
                        Created = DateTime.Now,
                        LastModifiedBy = null,
                        LastModified = null,

                        PostcardDate = date,
                        IdOnDate = numberOnDate,
                        Number = noFromCSV ?? null,
                        Description = descFromCSV ?? null,
                        AmountIssued = noIssuedFromCSV,
                        Atlas = atlasFromCSV ?? null,
                        Alberta = albertaFromCSV ?? null                        

                    };

                    var postcardThemesList = new List<PostcardTheme>();
                    //foreach (var theme in themes)
                    //{
                    //    var postcardTheme = new PostcardTheme
                    //    {
                    //        Postcard = id++,
                    //        Theme = theme.Id

                    //    };
                    //    postcardThemesList.Add(postcardTheme);
                    //}

                    
                    records.Add(record);
                }
                return records;
            }
        }

        private List<PostcardValue> GetPostcardValues(string seedFolder)
        {
            return new List<PostcardValue>
            {
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
            };
        }

        private List<PostcardType> GetPostcardTypes(string seedFolder)
        {
            return new List<PostcardType>
            {
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
            };
        }

        private List<Theme> GetThemes(string seedFolder)
        {
            string file = Path.Combine(seedFolder, "Themes.csv");
            Console.WriteLine("Theme seed location: " + file);

            var dictionary = new List<string>();
            using (var rd = new StreamReader(file))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    //string clean is done with Regex
                    dictionary.Add(Regex.Replace(splits[0], "[^A-Za-z0-9 ]", ""));
                }
            }

            var id = 1;
            var themeList = new List<Theme>();
            foreach (var theme in dictionary)
            {
                if (String.IsNullOrEmpty(theme))
                    continue;

                themeList.Add(new Theme
                {
                    Id = id++,
                    CreatedBy = "DataSeed",
                    Created = DateTime.Now,
                    LastModifiedBy = null,
                    LastModified = null,                    
                    Name = theme
                });


            }
            return themeList;
        }

        private List<Country> GetCountries()
        {
            return new List<Country> {
                    new Country
                    {
                        Id = 1,
                        Code = "VEN",
                        Created = DateTime.Now,
                        CreatedBy = "DataSeed",
                        LastModified = null,
                        LastModifiedBy = null,
                        Name = "Venda",
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
            };
        }

        private List<IssuedByEntity> GetIssuedByEntities(string seedFolder)
        {
            string issuedByEntitiesfile = Path.Combine(seedFolder, "IssuedByEntities.csv");
            var issuedByDictionary = new List<string>();
            using (var rd = new StreamReader(issuedByEntitiesfile))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(',');
                    //string clean is done with Regex
                    issuedByDictionary.Add(Regex.Replace(splits[0], "[^A-Za-z0-9() ]", ""));
                }
            }

            var id = 1;
            var list = new List<IssuedByEntity>();
            foreach (var entity in issuedByDictionary)
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

            return list;
        }
    }
}
