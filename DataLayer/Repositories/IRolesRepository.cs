namespace DataLayer.Repositories
{
    public interface IRolesRepository
    {
        public Task<Guid> GetRoleIdByName(string role);
    }
}
