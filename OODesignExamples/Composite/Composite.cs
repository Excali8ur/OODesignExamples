using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Composite
{
    /// <summary>
    /// Composite - A Composite stores child components in addition to implementing methods defined by the component interface. 
    /// Composites implement methods defined in the Component interface by delegating to child components. 
    /// In addition composites provide additional methods for adding, removing, as well as getting components.
    /// 
    /// Rectangle is a composite based on 4 lines (Leafs)
    /// </summary>
    public class Rectangle : iShape
    {
        /// <summary>
        /// List of shapes forming the rectangle
        //  Rectangle is centered around origin
        /// </summary>
        List<iShape> rectangleEdges;
        public Rectangle()
        {
            rectangleEdges = new List<iShape>();
            rectangleEdges.Add(new Line(-1, -1, 1, -1));
            rectangleEdges.Add(new Line(-1, 1, 1, 1));
            rectangleEdges.Add(new Line(-1, -1, -1, 1));
            rectangleEdges.Add(new Line(1, -1, 1, 1));
        }

        public List<iShape> ExplodeShape()
        {
            return rectangleEdges;
        }

        /// <summary>
        /// This method is implemented directly in basic shapes.
        /// In complex shapes this method is implemented using delegation
        /// </summary>
        public void RenderShapeToScreen()
        {
            Console.WriteLine("Draw Rectangle");
            foreach (iShape s in rectangleEdges)
            {
                // delegate to child objects
                s.RenderShapeToScreen();
            }
        }
    }

    public class House : iShape
    {
        List<iShape> edges;
        public House()
        {
            edges = new List<iShape>();
            edges.Add(new Rectangle());
            edges.Add(new Line(-1, 2, 2, 1));
            edges.Add(new Line(1, 2, 2, -1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<iShape> ExplodeShape()
        {
            return edges;
        }

        //This method must be implemented in this simple shape
        public void RenderShapeToScreen()
        {
            Console.WriteLine("Draw Line");
            // logic to render this shape to screen
        }
    }

    /// <summary>
    /// Composite object supporting creation of more complex shapes Complex Shape
    /// </summary>
    public class ComplexShape : iShape
    {
        /// <summary>
        /// List of shapes 
        /// </summary>
        List<iShape> shapeList = new List<iShape>();

        /// <summary>
        /// Add new Shapes (either composites or leafs) to the shape
        /// </summary>
        /// <param name="shapeToAddToCurrentShape">The new shape to add</param>
        public void AddToShape(iShape shapeToAddToCurrentShape)
        {
            shapeList.Add(shapeToAddToCurrentShape);
        }

        public List<iShape> ExplodeShape()
        {
            return shapeList;
        }

        /// <summary>
        /// This method is implemented directly in basic shapes.
        /// In complex shapes this method is handled with delegation.
        /// </summary>
        public void RenderShapeToScreen()
        {
            Console.WriteLine("Draw ComplexShape");
            foreach (iShape s in shapeList)
            {
                // use delegation to handle this method
                s.RenderShapeToScreen();
            }
        }
    }
}
