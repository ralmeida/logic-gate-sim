using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA.Helpers
{
    public static class DictionaryExtensions
    {
        public static bool ContainsKey(this Dictionary<FPGA_ADDRESS, int> me, FPGA_ADDRESS keyAddress)
        {
            bool hasKey = false;
            foreach(KeyValuePair<FPGA_ADDRESS, int> item in me)
            {
                if (item.Key.Column == keyAddress.Column && item.Key.Row == keyAddress.Row) hasKey = true;
                if (hasKey) break;
            }
            return hasKey;
        }
    }
}
