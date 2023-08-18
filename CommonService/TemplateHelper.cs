using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonService
{
    public static class TemplateHelper
    {

        public static string GetDetailsMenu()
        {
            return $"Choose option:\n1.Send Money\n 2.Withdraw Money\n 3.Request Money\n 4.Transfers\n 5.Pay Merchant\n 6.Pay Bill\n 7.Airtime Topup\n8.Pay Taxi\n9.Buy Air Ticket\n 10.Cardless ATM\n11.My Account";
        }
    }
}
