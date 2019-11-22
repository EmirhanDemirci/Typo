using System;
using System.Collections.Generic;
using System.Text;
using Typo.Dal.Interfaces;

namespace Typo.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> Context;

        public Repository(IRepository<TEntity> context)
        {
            Context = context;
        }

        public bool Add(TEntity entity)
        {
            return Context.Add(entity);
        }

        /// <summary>
        /// READ
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Model</returns>
        //public TEntity GetById(int id)
        //{
        //    return Context.GetById(id);
        //}

        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="entity">Class model</param>
        /// <returns>Bool</returns>


        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="entity">Class model</param>
        /// <returns>Model</returns>
        //public bool Update(TEntity entity)
        //{
        //    return Context.Update(entity);
        //}

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="entity">Class model</param>
        /// <returns>Model</returns>
        //public bool Delete(TEntity entity)
        //{
        //    return Context.Delete(entity);
        //}
    }
}
