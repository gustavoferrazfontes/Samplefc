using SampleFC.RegisterAuthentication.Data.Context;
using SampleFC.SharedKernel.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SampleFC.RegisterAuthentication.Data.Config
{
    public class UserRegistrationUnitOfWork : IUnitOfWork
    {
        private readonly UserRegistrationContext _context;
        public UserRegistrationUnitOfWork(UserRegistrationContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            foreach (DbEntityEntry entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
