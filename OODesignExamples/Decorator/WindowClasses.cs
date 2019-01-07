using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Decorator
{
    //Window Interface 
    //Component window
    public interface iWindow
    {
        void RenderWindow();
    }

    //Window implementation 
    //Concrete implementation
    public class SimpleWindow : iWindow
    {
        public void RenderWindow()
        {
            // implementation of rendering details
            Console.WriteLine("Render Simpel Window");
        }
    }

    public class DecoratedWindow : iWindow
    {
        //private reference to the window being decorated 
        private iWindow privateWindowRefernce = null;

        public DecoratedWindow(iWindow windowRefernce)
        {
            this.privateWindowRefernce = windowRefernce;
        }

        public virtual void RenderWindow()
        {
            privateWindowRefernce.RenderWindow();
        }
    }

    //Concrete Decorator with extended state 
    //Scrollable window creates a window that is scrollable
    public class ScrollableWindow : DecoratedWindow
    {

        //Additional State 
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

    public class GUIDriver
    {
        public void Run()
        {
            // create a new window 
            iWindow window = new SimpleWindow();
            window.RenderWindow();

            // at some point later 
            // maybe text size becomes larger than the window 
            // thus the scrolling behavior must be added 

            // decorate old window 
            window = new ScrollableWindow(window);

            //  now window object 
            // has additional behavior / state
            window.RenderWindow();
        }
    }
}
