using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Decorator
{ 
    public class GUIDriver
    {
        public void Run()
        {
            // create a new window 
            iWindow window = new SimpleWindow();
            window.RenderWindow();

            // At some point later maybe text size becomes larger than the window,
            // thus the scrolling behavior must be added 

            // decorate old window 
            window = new ScrollableWindow(window);

            // The window object has additional behavior / state
            window.RenderWindow();
        }
    }
}
