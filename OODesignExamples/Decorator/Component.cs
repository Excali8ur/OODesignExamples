using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Decorator
{
    /// <summary>
    /// Component - Interface for objects that can have responsibilities added to them dynamically.
    /// </summary>
    public interface iWindow
    {
        void RenderWindow();
    }

    /// <summary>
    /// ConcreteComponent - Defines an object to which additional responsibilities can be added.
    /// </summary>
    public class SimpleWindow : iWindow
    {
        /// <summary>
        /// Implementation of rendering details
        /// </summary>
        public void RenderWindow()
        {            
            Console.WriteLine("Render Simpel Window");
        }
    }

}
