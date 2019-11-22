using System;
using System.Collections.Generic;
using System.Text;

namespace Typo.Dal.Interfaces
{
    /// <summary>
    /// CRUD Operations
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public interface IRepository<T>
    {
        //T GetbyID(int id); //READ
        bool Add(T entity); 
        //bool Update(T entity);
        //bool Delete(T entity);
    }
}
