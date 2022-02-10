using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class CloneRepository : ICloneRepository, IDisposable
    {
        private SWContext _swContext;
        public CloneRepository(SWContext swContext)
        {
            _swContext = swContext;
        }
        public void DeleteClone(int cloneID)
        {
            Clone clone = _swContext.Clones.Find(cloneID);
            _swContext.Clones.Remove(clone);
        }

        public Clone GetCloneByID(int cloneId)
        {
            return _swContext.Clones.Find(cloneId);
        }

        public IEnumerable<Clone> GetClones()
        {
            return _swContext.Clones.ToList();
        }

        public void InsertClone(Clone clone)
        {
            _swContext.Clones.Add(clone);
        }

        public void Save()
        {
            _swContext.SaveChanges();
        }

        public void UpdateClone(Clone clone)
        {
            _swContext.Entry(clone).State = EntityState.Modified;
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
