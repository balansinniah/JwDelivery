﻿using System;
using System.Threading.Tasks;

namespace EntityFramework.Core.Generic.Pattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        Task<int> Commit();
    }
}
