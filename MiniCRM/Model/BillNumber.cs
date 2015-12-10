using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Model
{
    public class BillNumber
    {
        private BillNumber() { }

        private static volatile int nextBillNumber = 0;

        public static void Next()
        {
            nextBillNumber++;
        }
        public static int GetCurrent()
        {
            return nextBillNumber;
        }
    }
}
