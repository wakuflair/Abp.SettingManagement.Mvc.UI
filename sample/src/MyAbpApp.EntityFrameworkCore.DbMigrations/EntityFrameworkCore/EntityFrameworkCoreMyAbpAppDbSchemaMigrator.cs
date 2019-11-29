using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAbpApp.Data;
using Volo.Abp.DependencyInjection;

namespace MyAbpApp.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreMyAbpAppDbSchemaMigrator 
        : IMyAbpAppDbSchemaMigrator, ITransientDependency
    {
        private readonly MyAbpAppMigrationsDbContext _dbContext;

        public EntityFrameworkCoreMyAbpAppDbSchemaMigrator(MyAbpAppMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}