using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Command
{
    public interface iOrder
    {
        void Execute();
    }

    // Receiver class.
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

    // Invoker.
    public class Agent
    {
        private List<iOrder> ordersQueue = new List<iOrder>();

        public Agent()
        {
        }

        public void PlaceOrder(iOrder order)
        {
            ordersQueue.Add(order);
            ordersQueue[0].Execute();
            ordersQueue.RemoveAt(0);
        }
    }

    //ConcreteCommand Class.
    public class BuyStockOrder : iOrder
    {
        private StockTrade stock;
        public BuyStockOrder(StockTrade st)
        {
            stock = st;
        }
        public void Execute()
        {
            stock.Buy();
        }
    }

    //ConcreteCommand Class.
    public class SellStockOrder : iOrder
    {
        private StockTrade stock;
        public SellStockOrder(StockTrade st)
        {
            stock = st;
        }
        public void Execute()
        {
            stock.Sell();
        }
    }

    // Client
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