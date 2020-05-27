using System;
using System.Runtime;
using System.Runtime.InteropServices;

namespace MoneyExchangeApp
{
    public class InternetCS
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
    }
}