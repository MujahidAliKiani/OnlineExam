using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Student;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace OnlineExamSystem.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See OnlineExamSystemDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class OnlineExamSystemMigrationsDbContext : AbpDbContext<OnlineExamSystemMigrationsDbContext>
    {
        public OnlineExamSystemMigrationsDbContext(DbContextOptions<OnlineExamSystemMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside the ConfigureOnlineExamSystem method */


            builder.Entity<OES_Student>(b =>
            {
                b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId);
            });

            builder.ConfigureOnlineExamSystem();
            builder.ConfigureBlobStoring();
        }
    }
}