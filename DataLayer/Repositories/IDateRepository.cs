namespace DataLayer.Repositories
{
    public interface IDateRepository
    {
        public Task<int?> GetDateIdByMonthAndYear(int month, int year);
    }
}
