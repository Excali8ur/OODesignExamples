using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Decorator
{
    /// <summary>
    /// Decorator - Maintains a reference to a Component object and defines an interface that conforms to Component's interface.
    /// </summary>
    public class DecoratedWindow : iWindow
    {
        /// <summary>
        /// Private reference to the window being decorated 
        /// </summary>
        private iWindow privateWindowRefernce = null;

        public DecoratedWindow(iWindow windowRefernce)
        {
            privateWindowRefernce = windowRefernce;
        }

        public virtual void RenderWindow()
        {
            privateWindowRefernce.RenderWindow();
        }
    }

    /// <summary>
    /// Concrete Decorators - Concrete Decorators extend the functionality of the component by adding state or adding behavior.
    /// Scrollable window creates a window that is scrollable
    /// </summary>
    public class ScrollableWindow : DecoratedWindow
    {
        /// <summary>
        /// Additional State
        /// </summary>
        private Object scrollBarObjectRepresentation = null;

        public ScrollableWindow(iWindow windowReference) : base(windowReference)
        {
        }

        public override void RenderWindow()
        {
            // render scroll bar 
            RenderScrollBarObject();
            // render decorated window
            base.RenderWindow();
        }

        private void RenderScrollBarObject()
        {
            // prepare scroll bar 
            scrollBarObjectRepresentation = new Object();
            // render scrollbar 
            Console.Write("RenderScrollBarObject");
        }
    }
}
