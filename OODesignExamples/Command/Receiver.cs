using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Command
{
    /// <summary>
    /// Receiver - knows how to perform the operations;
    /// </summary>
    public class StockTrade
    {
        public void Buy()
        {
            Console.WriteLine("You want to buy stocks");
        }
        public void Sell()
        {
            Console.WriteLine("You want to sell stocks ");
        }
    }
}
