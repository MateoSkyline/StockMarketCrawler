using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketCrawler.Models
{
    public class Status
    {
        public static int NotActive
        {
            get
            {
                return 0;
            }
        }

        public static int Waiting
        {
            get
            {
                return 1;
            }
        }
        
        public static int Running
        {
            get
            {
                return 2;
            }
        }

        public static int Crashed
        {
            get
            {
                return 3;
            }
        }
    }
}
