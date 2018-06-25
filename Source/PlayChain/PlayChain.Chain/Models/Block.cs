using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayChain.Chain.Models
{
    public class Block
    {
        public int BlockId { get; set; }
        public List<Transaction> Transaction { get; set; }
        public string Proof { get; set; }
        public string PreviousProof { get; set; }
        public DateTime TimeStamp { get; set; }
        public string FinderAddress { get; set; }
    }
}
