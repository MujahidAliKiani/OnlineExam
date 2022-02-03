using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Class;

using OnlineExamSystem.Users;
using OnlineExamSystem.Student;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using OnlineExamSystem.Test;
using OnlineExamSystem.Test_Item;

namespace OnlineExamSystem.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See OnlineExamSystemMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class OnlineExamSystemDbContext : AbpDbContext<OnlineExamSystemDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<OES_Class> OES_Class { get; set; }
        public DbSet<OES_Student> OES_Student { get; set; }
        public DbSet<OES_Test> OES_Test  { get; set; }
        public DbSet<OES_Test_Item>Test_Items { get; set; }



        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside OnlineExamSystemDbContextModelCreatingExtensions.ConfigureOnlineExamSystem
         */

        public OnlineExamSystemDbContext(DbContextOptions<OnlineExamSystemDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();


                /* Configure mappings for your additional properties
                 * Also see the OnlineExamSystemEfCoreEntityExtensionMappings class
                 */
            });
            builder.Entity<OES_Student>(b =>
            {
                b.HasOne<AppUser>().WithMany().HasForeignKey(x => x.UserId);
            });
            /* Configure your own tables/entities inside the ConfigureOnlineExamSystem method */

            builder.ConfigureOnlineExamSystem();
        }
    }
}
