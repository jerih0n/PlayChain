using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayChain.Chain.Models
{
    /// <summary>
    /// For not confirm transactions
    /// </summary>
    public class MemPool
    {
        public List<Transaction> PendingTransactions { get; set; }
    }
}
