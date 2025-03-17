﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucktive.Core.Repositories;
using Trucktive.Repositories._Data;

namespace Trucktive.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Hashtable _repositories;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }


        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name; // ex: Order

            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<TEntity>(_dbContext);

                _repositories.Add(key, repository);
            }

            return _repositories[key] as IGenericRepository<TEntity>;
        }


        public async Task<int> CompleteAsync()
         => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
        => await _dbContext.DisposeAsync();

    }
}
