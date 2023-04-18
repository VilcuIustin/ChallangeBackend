namespace DataLayer
{
    internal static class StoredProcedures
    {
        internal static string CheckIfEmailExists => "Sp_CheckIfEmailExists";
        internal static string CheckIfUserExistsById => "Sp_CheckIfUserExistsById";
        internal static string CreateUser => "Sp_CreateUser";
        internal static string GetRoleIdByName => "Sp_GetRoleIdByName";
        internal static string CreateUserRole => "Sp_CreateUserRole";
        internal static string GetUserForLogin => "Sp_GetUserForLogin";
        internal static string CheckIfProductExistByName => "Sp_CheckIfProductExistByName";
        internal static string CheckIfProductExistById => "Sp_CheckIfProductExistById";
        internal static string CheckIfProductRewardExistByNameAndDate => "Sp_CheckIfProductRewardExistByNameAndDate";
        internal static string AddProduct => "Sp_AddProduct";
        internal static string GetProductsPaginated => "Sp_GetProductsPaginated";
        internal static string GetDateIdByMonthAndYear => "Sp_GetDateIdByMonthAndYear";
        internal static string AddProductReward => "Sp_AddProductReward";
        internal static string AddEmployeeSales => "Sp_AddEmployeeSales";
        internal static string GetActiveEmployees => "Sp_GetActiveEmployees";
        internal static string GetProductRewards => "Sp_GetProductRewards";
        internal static string GetEmployeesSalesByDate => "Sp_GetEmployeesSalesByDate";
        internal static string ProductRewardsExistsById => "Sp_ProductRewardsExistsById";
        internal static string UpdateProductReward => "Sp_UpdateProductReward";
        internal static string CalculateRewards => "Sp_CalculateRewards";
        internal static string GetEmployeesSalesById => "Sp_GetEmployeesSalesById";
        internal static string UpdateEmployeesSales => "Sp_UpdateEmployeesSales";
    }
}
