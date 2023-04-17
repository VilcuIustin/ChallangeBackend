using Common.DTOs.Models;
using Common.DTOs.Responses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RemunerationRepository : BaseRepository, IRemunerationRepository
    {
        public RemunerationRepository(SqlTransaction transaction) : base(transaction)
        {
        }

        public async Task<List<SalesByProductResponse>> GetRemunerationByDateAsync(int dateId)
        {
            var remuneration = await _connection.QueryAsync<MinimalEmployeeDetails, SalesByProductResponse, int, SalesByProductResponse>(
                StoredProcedures.CalculateRewards, (user, product, remuneration) =>
                {
                    product.EmployeesRemuneration.Add(new EmployeeRemunerationResponse
                    {
                        Name = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id,
                        Remuneration = remuneration
                    });
                    return product;
                },
                new {dateId}, splitOn: "id,productId,RewardAmount",
                transaction:_transaction, commandType: CommandType.StoredProcedure);

            return remuneration.GroupBy(r => r.ProductId)
                .Select(r =>
                {
                    var productDetails = r.First();
                    productDetails.EmployeesRemuneration = r.SelectMany(p => p.EmployeesRemuneration).ToList();
                    return productDetails;
                }).ToList();
        }
    }
}
