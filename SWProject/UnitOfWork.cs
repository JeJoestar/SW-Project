using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SWContext _swContext = new SWContext();
        private GenericRepository<Clone> _cloneRepository;
        private GenericRepository<Droid> _droidRepository;

        public GenericRepository<Clone> CloneRepository
        {
            get
            {

                if (_cloneRepository == null)
                {
                    _cloneRepository = new GenericRepository<Clone>(_swContext);
                }
                return _cloneRepository;
            }
        }

        public GenericRepository<Droid> DroidRepository
        {
            get
            {

                if (_droidRepository == null)
                {
                    _droidRepository = new GenericRepository<Droid>(_swContext);
                }
                return _droidRepository;
            }
        }

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
