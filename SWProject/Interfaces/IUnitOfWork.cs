using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        public IGenericRepository<Clone> CloneRepository { get; }
        public IGenericRepository<Droid> DroidRepository { get; }
        public void Save();
        
    }
}
