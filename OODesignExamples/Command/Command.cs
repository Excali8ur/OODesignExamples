using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Command
{
    /// <summary>
    /// Command - declares an interface for executing an operation;
    /// </summary>
    public interface iOrder
    {
        void Execute();
    }

    /// <summary>
    /// ConcreteCommand - extends the Command interface, implementing the Execute method by invoking the corresponding operations on Receiver. It defines a link between the Receiver and the action.
    /// </summary>
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

    /// <summary>
    /// ConcreteCommand - extends the Command interface, implementing the Execute method by invoking the corresponding operations on Receiver. It defines a link between the Receiver and the action.
    /// </summary>
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

}
