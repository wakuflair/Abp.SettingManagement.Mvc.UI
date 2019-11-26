using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Abp.SettingManagement.Mvc.UI.EntityFrameworkCore
{
    public static class AbpSettingManagementMvcUIDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpSettingManagementMvcUI(
            this ModelBuilder builder,
            Action<AbpSettingManagementMvcUIModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AbpSettingManagementMvcUIModelBuilderConfigurationOptions(
                AbpSettingManagementMvcUIDbProperties.DbTablePrefix,
                AbpSettingManagementMvcUIDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureFullAuditedAggregateRoot();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}