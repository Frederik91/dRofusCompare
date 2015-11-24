using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRofusCompare.Models
{
    public class dRofusData
    {
        public string Room { get; set; }
        public int UPRI { get; set; }
        public int PRI { get; set; }
        public int UPS { get; set; }
        public int Data { get; set; }
        public int Power { get { return UPRI + PRI + UPS; } }
    }
}
