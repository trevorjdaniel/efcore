using System;
using System.Collections.Generic;
using System.Text;
using ICMASync.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ICMASync.Data
{
    public interface IBaseContextFactory
    {
        BaseContext Create();
    }

    public class BaseContextFactory : IBaseContextFactory
    {
        private readonly DbContextOptions<BaseContext> _dbContextOptions;

        public BaseContextFactory(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<BaseContext>();
            builder.UseSqlServer(connectionString);
            _dbContextOptions = builder.Options;
        }

        public BaseContextFactory(DbContextOptions<BaseContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public BaseContext Create()
        {
            return new BaseContext(_dbContextOptions);
        }
    }
}
