using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Composite
{
    /// <summary>
    /// Client - The client manipulates objects in the hierarchy using the component interface.
    /// </summary>
    public class GraphicsEditor
    {
        public void Run()
        {
            List<iShape> allShapesInSoftware = new List<iShape>();

            // create a line shape
            iShape lineShape = new Line(0, 0, 1, 1);
            // add it to the shapes 
            allShapesInSoftware.Add(lineShape);

            // create a rectangle shape
            iShape rectangelShape = new Rectangle();
            // add it to shapes 
            allShapesInSoftware.Add(rectangelShape);

            // create a complex shape 
            // note that we have dealt with the complex shape 
            // not with shape interface because we want 
            // to do a specific operation 
            // that does not apply to all shapes 
            ComplexShape complexShape = new ComplexShape();

            // complex shape is made of the rectangle and the line 
            complexShape.AddToShape(rectangelShape);
            complexShape.AddToShape(lineShape);

            // add to shapes
            allShapesInSoftware.Add(complexShape);

            // create a more complex shape which is made of the 
            // previously created complex shape 
            // as well as a line 
            ComplexShape veryComplexShape = new ComplexShape();

            veryComplexShape.AddToShape(complexShape);
            veryComplexShape.AddToShape(lineShape);
            allShapesInSoftware.Add(veryComplexShape);

            RenderGraphics(allShapesInSoftware);

            // you can explode any object
            // despite the fact that the shape might be 
            // simple or complex

            List<iShape> arrayOfShapes = allShapesInSoftware[0].ExplodeShape();
        }

        private static void RenderGraphics(List<iShape> shapesToRender)
        {
            // note that despite the fact there are 
            // simple and complex shapes 
            // this method deals with them uniformly 
            // and using the Shape interface
            foreach (iShape s in shapesToRender)
            {
                s.RenderShapeToScreen();
            }
        }
    }
}

