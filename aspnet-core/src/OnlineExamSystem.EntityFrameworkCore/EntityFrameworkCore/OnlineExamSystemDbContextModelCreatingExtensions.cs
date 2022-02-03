using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Class;
using OnlineExamSystem.Student;
using OnlineExamSystem.Test;
using OnlineExamSystem.Test_Item;
using OnlineExamSystem.Users;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace OnlineExamSystem.EntityFrameworkCore
{
    public static class OnlineExamSystemDbContextModelCreatingExtensions
    {
        public static void ConfigureOnlineExamSystem(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(OnlineExamSystemConsts.DbTablePrefix + "YourEntities", OnlineExamSystemConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

        

            builder.Entity<OES_Class>(b =>
            {
                b.ToTable(OnlineExamSystemConsts.DbTablePrefix + "OES_Class",
                          OnlineExamSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Id).IsRequired().HasMaxLength(128);
            });
            builder.Entity<OES_Student>(b =>
            {
                b.ToTable(OnlineExamSystemConsts.DbTablePrefix + "OES_Student",
                          OnlineExamSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Id).IsRequired().HasMaxLength(128);
    
            });
            builder.Entity<OES_Test>(b =>
            {
                b.ToTable(OnlineExamSystemConsts.DbTablePrefix + "OES_Test",
                          OnlineExamSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Id).IsRequired().HasMaxLength(128);

                //b.HasOne(e => e.OES_Class).WithMany().OnDelete(DeleteBehavior.NoAction);
                //b.HasOne(e => e.Student).WithMany().OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<OES_Test_Item>(b =>
            {
                b.ToTable(OnlineExamSystemConsts.DbTablePrefix + "OES_Test_Item",
                          OnlineExamSystemConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Id).IsRequired().HasMaxLength(128);
               
            });
        }
    }
}