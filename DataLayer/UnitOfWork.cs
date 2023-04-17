using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        public IUserRepository userRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public IProductRewardsRepository ProductRewardsRepository { get; }
        public IDateRepository DateRepository { get; }
        public IEmployeeSalesRepository EmployeeSalesRepository { get; }
        public IEmployeesRepository EmployeesRepository { get; }
        public IRemunerationRepository RemunerationRepository { get; }
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("Database"));
            _connection.Open();
            _transaction = StartTransaction();
            userRepository = new UserRepository(_transaction);
            UserRoleRepository = new UserRoleRepository(_transaction);
            RolesRepository = new RolesRepository(_transaction);
            ProductsRepository = new ProductsRepository(_transaction);
            ProductRewardsRepository = new ProductRewardRepository(_transaction);
            DateRepository = new DateRepository(_transaction);
            EmployeeSalesRepository = new EmployeeSalesRepository(_transaction);
            EmployeesRepository = new EmployeesRepository(_transaction);
            RemunerationRepository = new RemunerationRepository(_transaction);
        }

        public Task SaveChangesAsync() => _transaction.CommitAsync();

        public SqlTransaction StartTransaction() => _connection.BeginTransaction();

        public Task RollbackAsync()
            => _transaction.RollbackAsync();
    }
}
