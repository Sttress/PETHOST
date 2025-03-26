using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.Common.Repositories.Pagination
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Apply in-memory changes to the resource destination.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Number of records affected.</returns>
        Task<int> ApplyChangesAsync(CancellationToken cancellationToken = default);
    }
}
