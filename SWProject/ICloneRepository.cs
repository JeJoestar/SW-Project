using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public interface ICloneRepository : IDisposable
    {
        IEnumerable<Clone> GetClones();
        Clone GetCloneByID(int cloneId);
        void InsertClone(Clone clone);
        void DeleteClone(int cloneId);
        void UpdateClone(Clone clone);
        void Save();
    }
}
