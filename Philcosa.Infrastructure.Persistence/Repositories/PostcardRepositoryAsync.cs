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
    public class PostcardRepositoryAsync : GenericRepositoryAsync<Postcard>, IPostcardRepositoryAsync
    {
        private readonly DbSet<Postcard> _postcards;

        public PostcardRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _postcards = dbContext.Set<Postcard>();
        }      
    }
}
