using System.Threading.Tasks;

namespace OnlineExamSystem.Data
{
    public interface IOnlineExamSystemDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
