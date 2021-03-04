using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RivTech.WebService.Generic.DataProvider.Repository
{
    public interface IBaseRepository<T>
    {
        bool Exist(object id);
        /// <summary>
        ///     Adds an in memory database entry.
        /// </summary>
        /// <param>
        ///   entity:
        ///     Object of the entry to be added.
        /// </param>
        /// <returns>
        ///     Added in memory entry.
        /// </returns>
        string Add(T entity);

        /// <summary>
        ///     Updates the values of an in memory database entry.
        ///
        /// <param>
        ///   entity:
        ///     Object of the entry to be updated.
        /// </param>
        /// <returns>
        ///     Updated in memory entry.
        /// </returns>
        string Update(T entity);

        /// <summary>
        ///     Deletes the entry in memory using the provided id.
        ///
        /// <param>
        ///   entity:
        ///     Object of the entry to be deleted.
        /// </param>
        string Remove(object id);

        /// <summary>
        ///     Deletes all entry object in memory.
        ///
        /// <param>
        ///   entities:
        ///     Collection of objects to be deleted.
        /// </param>
        string RemoveRange(T[] entities);

        //Find by id
        public T Find(object id, string[] includedProperties = null);

        /// <summary>
        ///     Finds all records.
        ///
        /// <param>
        ///   includedProperties:
        ///     (Optional) Array of strings of the included navigation properties on the result record. Ex: new string[] {"MyProperty"}.
        /// </param>
        /// <returns>
        ///     An System.Linq.IQueryable expressions that holds all records.
        /// </returns>
        IEnumerable<T> FindAll(string[] includedProperties = null);

        /// <summary>
        ///     Completes the unit of work and saves the work done.
        /// </summary>
        void SaveChanges();
    }
}
