using Dapper;
using System.Data;

namespace DataLayer
{
    public class DatabaseInit
    {
        private readonly UnitOfWork _unitOfWork;
        public DatabaseInit(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTablesAsync()
        {
            try
            {
                var scriptsFolder = Environment.CurrentDirectory + "\\DataLayer\\DatabaseScripts\\Database";
                var directory = new DirectoryInfo(scriptsFolder);
                var scripts = directory.GetFiles();

                string content = string.Empty;

                foreach (var script in scripts)
                {
                    content = File.ReadAllText(script.FullName);
                    await _unitOfWork._connection.ExecuteAsync(content, transaction: _unitOfWork.transaction);
                }

                var finalScript = Environment.CurrentDirectory + "\\DataLayer\\DatabaseScripts\\Start.sql";
                content = File.ReadAllText(finalScript);
                await _unitOfWork._connection.ExecuteAsync(content, transaction: _unitOfWork.transaction);
                await _unitOfWork._connection.ExecuteAsync("CreateDatabase", commandType:CommandType.StoredProcedure, transaction: _unitOfWork.transaction);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.transaction.RollbackAsync();
            }

        }

        public async Task CreateStoredProceduresAsync()
        {
            try
            {
                var scriptsFolder = Environment.CurrentDirectory + "\\DataLayer\\DatabaseScripts\\StoredProcedures";
                var directory = new DirectoryInfo(scriptsFolder);
                var scripts = directory.GetFiles();

                string content = string.Empty;

                foreach (var script in scripts)
                {
                    content = File.ReadAllText(script.FullName);
                    await _unitOfWork._connection.ExecuteAsync(content, transaction: _unitOfWork.transaction);
                }

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.transaction.RollbackAsync();
            }
        }

    }
}
