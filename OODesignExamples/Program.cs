using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODesignExamples.Command;
using OODesignExamples.Composite;
using OODesignExamples.Decorator;

namespace OODesignExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Command Pattern ---");
            StockTradeClient stc = new StockTradeClient();
            stc.Run();

            Console.WriteLine("\n--- Composite Pattern ---");
            GraphicsEditor ge = new GraphicsEditor();
            ge.Run();

            Console.WriteLine("\n--- Decorator Pattern ---");
            GUIDriver gd = new GUIDriver();
            gd.Run();

            Console.ReadLine();
        }
    }
}
