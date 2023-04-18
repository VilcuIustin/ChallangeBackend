using DataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public readonly SqlConnection _connection;
        public SqlTransaction _transaction;
        public SqlTransaction transaction => _transaction ?? StartTransaction();
        public IUserRepository UserRepository { get; }
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
            UserRepository = new UserRepository(transaction);
            UserRoleRepository = new UserRoleRepository(transaction);
            RolesRepository = new RolesRepository(transaction);
            ProductsRepository = new ProductsRepository(transaction);
            ProductRewardsRepository = new ProductRewardRepository(transaction);
            DateRepository = new DateRepository(transaction);
            EmployeeSalesRepository = new EmployeeSalesRepository(transaction);
            EmployeesRepository = new EmployeesRepository(transaction);
            RemunerationRepository = new RemunerationRepository(transaction);
        }

        public Task SaveChangesAsync() => transaction.CommitAsync();

        public SqlTransaction StartTransaction()
        {
            _transaction = _connection.BeginTransaction();
            return _transaction;
        }

        public Task RollbackAsync()
            => transaction.RollbackAsync();
    }
}
