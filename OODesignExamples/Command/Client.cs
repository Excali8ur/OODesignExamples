using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Command
{
    /// <summary>
    /// Client - creates a ConcreteCommand object and sets its receiver;
    /// </summary>
    public class StockTradeClient
    {
        public void Run()
        {
            StockTrade stock = new StockTrade();
            BuyStockOrder bsc = new BuyStockOrder(stock);
            SellStockOrder ssc = new SellStockOrder(stock);
            Agent agent = new Agent();

            agent.PlaceOrder(bsc); // Buy Shares
            agent.PlaceOrder(ssc); // Sell Shares
        }
    }
}