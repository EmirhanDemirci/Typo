using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Typo.Dal.Interfaces
{
    public interface ICrud<T>
    {
        void Create(T obj);
        T Read(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
