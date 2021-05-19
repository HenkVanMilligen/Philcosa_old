using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Philcosa.Domain.Entities;
using Philcosa.Infrastructure.Identity;
using Philcosa.Infrastructure.Identity.Models;
using Philcosa.Infrastructure.Persistence.Contexts;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Philcosa.WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            using (var context = new ApplicationDbContext())
            {
                SeedPostcardData(context);
            }

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            host.Run();
        }

        private static void SeedPostcardData(ApplicationDbContext context)
        {
            var countries = context.Countries.ToList();
            var issuedByEntities = context.IssuedByEntities.ToList();
            var themes = context.Themes.ToList();
            var types = context.PostcardTypes.ToList();
            var values = context.PostcardValues.ToList();

            string seedFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Philcosa.Infrastructure.Persistence\\Seeds\\";
            List<Postcard> postcards = GetPostcards(seedFolder, countries, issuedByEntities, themes, types, values);

            foreach (var postcard in postcards)
            {
                try
                {
                    foreach (var pt in postcard.PostcardThemes)
                    {
                        context.Add(pt);
                    }
                    context.Add(postcard);

                    
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            context.SaveChanges();
        }

        private static List<Postcard> GetPostcards(string seedFolder, List<Country> countries, List<IssuedByEntity> issuedByEntities, List<Theme> themes,
            List<PostcardType> types, List<PostcardValue> values)
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
                    var postcardId = id++;
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
                    var postcardThemeList = new List<PostcardTheme>();
                    foreach (var themeForPostcard in themesList)
                    {                        
                        var postcardTheme = new PostcardTheme
                        {
                            PostcardId = postcardId,
                            ThemeId = themeForPostcard.Id
                        };
                        postcardThemeList.Add(postcardTheme);
                    }
                    var postcard = new Postcard
                    {
                        Id = postcardId,
                        CreatedBy = "DataSeed",
                        Created = DateTime.Now,
                        LastModifiedBy = null,
                        LastModified = null,

                        PostcardDate = date,
                        IdOnDate = numberOnDate,
                        IssuedBy = issuedByEntities.SingleOrDefault(x => x.Code == issuedByFromCSV),
                        Number = noFromCSV ?? null,
                        Description = descFromCSV ?? null,
                        AmountIssued = noIssuedFromCSV,
                        Atlas = atlasFromCSV ?? null,
                        Alberta = albertaFromCSV ?? null,
                        PostcardType = types.SingleOrDefault(x => x.Name == typeFromCSV),
                        Value = values.SingleOrDefault(x => x.Code == valueFromCSV),
                        Country = countries.SingleOrDefault(x => x.Code == areaFromCSV),
                        PostcardThemes = postcardThemeList
                        
                    };
                    records.Add(postcard);
                }
                return records;
            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
       .UseSerilog() //Uses Serilog instead of default .NET Logger
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           });

    }
}
