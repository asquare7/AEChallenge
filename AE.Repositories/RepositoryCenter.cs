using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AE.Models.Base;
using AE.Models.Data;
using System.Net.Http;
using AE.Repositories.Base;
using AE.Repositories.EntityRepo;
using AE.Repositories.EntityRepoBase;


namespace AE.Repositories
{
    public class RepositoryCenter : IRepositoryCenter
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public IShipRepository ShipRepo { get; private set; }
        public IPortRepository PortRepo { get; private set; }

        public RepositoryCenter(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            ShipRepo = new ShipRepository(context, _logger);
            PortRepo = new PortRepository(context, _logger);
        }

        public async Task CommitAsync()
        {
            var modifiedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IAudit)
                {
                    ((IAudit)entry.Entity).ChangedDate = DateTime.UtcNow;
                }

            }

            var addedEntries = _context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                if (entry.Entity is IAudit)
                {
                    ((IAudit)entry.Entity).CreatedDate = DateTime.UtcNow;
                }
            }

            _context.ChangeTracker.DetectChanges();
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
