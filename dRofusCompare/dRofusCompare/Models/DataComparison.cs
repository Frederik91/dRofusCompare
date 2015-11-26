using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dRofusCompare.Models
{
    public class DataComparison
    {
        public string Room { get; set; }
        public int dRofusPower { get; set; }
        public int dRofusTele { get; set; }
        public int DrawingPower { get; set; }
        public int DrawingTele { get; set; }
        public int DifferencePower { get; set; }
        public int DifferenceTele { get; set; }
    }
}
