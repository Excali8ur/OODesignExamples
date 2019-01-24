using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Command
{
    /// <summary>
    /// Invoker - asks the command to carry out the request;
    /// </summary>
    public class Agent
    {
        private List<iOrder> ordersQueue = new List<iOrder>();

        public void PlaceOrder(iOrder order)
        {
            ordersQueue.Add(order);
            ordersQueue[0].Execute();
            ordersQueue.RemoveAt(0);
        }
    }
}