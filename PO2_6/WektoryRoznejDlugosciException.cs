using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO2_6
{
    internal class WektoryRoznejDlugosciException : Exception
    {
        int l1;
        int l2;
        public WektoryRoznejDlugosciException(int l1, int l2)
        {
            this.l1 = l1;
            this.l2 = l2;
        }
        public IEnumerable<int> lengths()
        {
            yield return l1;
            yield return l2;
        }
    }
}
