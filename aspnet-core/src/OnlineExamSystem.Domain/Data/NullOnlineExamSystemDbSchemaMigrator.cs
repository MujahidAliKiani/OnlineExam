using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OnlineExamSystem.Data
{
    /* This is used if database provider does't define
     * IOnlineExamSystemDbSchemaMigrator implementation.
     */
    public class NullOnlineExamSystemDbSchemaMigrator : IOnlineExamSystemDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}