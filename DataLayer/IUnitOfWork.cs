using DataLayer.Repositories;
using System.Data.SqlClient;

namespace DataLayer
{
    public interface IUnitOfWork
    {
        public IUserRepository userRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }
        public IRolesRepository RolesRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public IProductRewardsRepository ProductRewardsRepository { get; }
        public IDateRepository DateRepository { get; }
        public IEmployeeSalesRepository EmployeeSalesRepository { get; }
        public IEmployeesRepository EmployeesRepository { get; }
        public IRemunerationRepository RemunerationRepository { get; }
        public SqlTransaction StartTransaction();
        public Task RollbackAsync();
        public Task SaveChangesAsync();
    }
}
