using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal static class StoredProcedures
    {
        internal static string CheckIfEmailExists => "CheckIfEmailExists";
        internal static string CheckIfUserExistsById => "CheckIfUserExistsById";
        internal static string CreateUser => "CreateUser";
        internal static string GetRoleIdByName => "GetRoleIdByName";
        internal static string CreateUserRole => "Sp_CreateUserRole";
        internal static string GetUserForLogin => "Sp_GetUserForLogin";
        internal static string CheckIfProductExistByName => "CheckIfProductExistByName";
        internal static string CheckIfProductExistById => "CheckIfProductExistById";
        internal static string CheckIfProductRewardExistByNameAndDate => "CheckIfProductRewardExistByNameAndDate";
        internal static string AddProduct => "AddProduct";
        internal static string GetProductsPaginated => "GetProductsPaginated";
        internal static string GetDateIdByMonthAndYear => "GetDateIdByMonthAndYear";
        internal static string AddProductReward => "AddProductReward";
        internal static string AddEmployeeSales => "AddEmployeeSales";
        internal static string GetActiveEmployees => "GetActiveEmployees";
        internal static string GetProductRewards => "GetProductRewards";
        internal static string GetEmployeesSalesByDate => "GetEmployeesSalesByDate";
        internal static string ProductRewardsExistsById => "ProductRewardsExistsById";
        internal static string UpdateProductReward => "UpdateProductReward";
        internal static string CalculateRewards => "CalculateRewards";
    }
}
