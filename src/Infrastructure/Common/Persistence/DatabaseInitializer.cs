namespace ShopingRequestSystem.Infrastructure.Common.Persistence
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using ShopingRequestSystem.Infrastructure.Common;

    internal class DatabaseInitializer : IInitializer
    {
        private readonly ShopingDbContext db;

        public DatabaseInitializer(ShopingDbContext db)
        {
            this.db = db;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();
            this.db.SaveChanges();
        }

        private bool DataSetIsEmpty(Type type)
        {
            var setMethod = this.GetType()
                .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(type);

            var set = setMethod.Invoke(this, Array.Empty<object>());

            var countMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
                .MakeGenericMethod(type);

            var result = (int)countMethod.Invoke(null, new[] { set })!;

            return result == 0;
        }

        private DbSet<TEntity> GetSet<TEntity>()
            where TEntity : class
            => this.db.Set<TEntity>();
    }
}
