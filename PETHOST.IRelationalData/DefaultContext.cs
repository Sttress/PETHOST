using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PETHOST.Common.Repositories.Pagination;
using PETHOST.Domain.Entities;


namespace PETHOST.IRelationalData
{
    public class DefaultContext : DbContext, IUnitOfWork
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAdmin> UsersAdmin { get; set; }
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        /// <inheritdoc/>
        public async Task<int> ApplyChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return 0;
            }
        }
    }
}
