using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Typo.Dal.Interfaces
{
    //interfaces to execute Crud operation (Create, Read, Update, Delete)
    public interface ICrud<T>
    {
        void Create(T obj);
        T Read(T obj);
        void Update(T obj);
        bool Delete(T obj);
    }
}
