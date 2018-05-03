﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Interfaces
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        /// <summary>
        /// Begin transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit Async
        /// </summary>
        Task<int> CommitAsync();

        /// <summary>
        /// Commit
        /// </summary>
        int Commit();
    }
}
