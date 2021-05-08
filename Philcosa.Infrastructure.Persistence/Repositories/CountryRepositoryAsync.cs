using Microsoft.EntityFrameworkCore;
using Philcosa.Application.Interfaces.Repositories;
using Philcosa.Domain.Entities;
using Philcosa.Infrastructure.Persistence.Contexts;
using Philcosa.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Repositories
{
    public class CountryRepositoryAsync : GenericRepositoryAsync<Country>, ICountryRepositoryAsync
    {
        private readonly DbSet<Country> _countries;

        public CountryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _countries = dbContext.Set<Country>();
        }      
    }
}
