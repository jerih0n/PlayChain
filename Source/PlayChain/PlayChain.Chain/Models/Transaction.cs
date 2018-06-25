using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayChain.Chain.Models
{
    public class Transaction
    {
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public long Value { get; set; }
        public DateTime Date { get; set; }
        public bool Verifued { get; set; }
        public bool Rejected { get; set; }
    }
}
