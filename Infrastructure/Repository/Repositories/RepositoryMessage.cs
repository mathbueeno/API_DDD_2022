using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {
        private readonly DbContextOptions<DataContext> _dataContext;

        public RepositoryMessage()
        {
            _dataContext= new DbContextOptions<DataContext>();
        }

        public async Task<List<Message>> ListarMessage(Expression<Func<Message, bool>> exMessage)
        {
            using (var banco = new DataContext(_dataContext))
            {
                return await banco.Messages.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
