using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private SWContext _swContext = new SWContext();
        private IGenericRepository<Clone> _cloneRepository;
        private IGenericRepository<Droid> _droidRepository;

        public IGenericRepository<Clone> CloneRepository
            => _cloneRepository ?? (_cloneRepository = new GenericRepository<Clone>(_swContext));

        public IGenericRepository<Droid> DroidRepository
            => _droidRepository ?? (_droidRepository = new GenericRepository<Droid>(_swContext));

        public void Save()
        {
            _swContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _swContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
