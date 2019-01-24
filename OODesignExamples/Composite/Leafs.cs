using System;
using System.Collections.Generic;

namespace OODesignExamples.Composite
{
    /// <summary>
    /// Leaf - Leafs are objects that have no children. 
    /// They implement services described by the Component interface. 
    /// For example a file object implements move, copy, rename, as well as getSize methods which are related to the Component interface.
    /// 
    /// Line is a basic shape that does not support adding shapes
    /// </summary>
    public class Line : iShape
    {
        private int startPointX;
        private int startPointY;
        private int endPointX;
        private int endPointY;

        /// <summary>
        /// Leaf - Leafs are objects that have no children. 
        /// They implement services described by the Component interface. 
        /// For example a file object implements move, copy, rename, as well as getSize methods which are related to the Component interface.
        /// </summary>
        /// <param name="point1X">x coord of starting-point</param>
        /// <param name="point1Y">y coord of starting-point</param>
        /// <param name="point2X">x coord of end-point</param>
        /// <param name="point2Y">y coord of end-point</param>
        public Line(int point1X, int point1Y, int point2X, int point2Y)
        {
            startPointX = point1X;
            startPointY = point1Y;
            endPointX = point2X;
            endPointY = point2Y;
        }

        /// <summary>
        /// Making a simple shape explode would return only the shape itself, there are no parts of this shape
        /// </summary>
        /// <returns></returns>
        public List<iShape> ExplodeShape()
        {            
            List<iShape> shapeParts = new List<iShape>();
            shapeParts.Add(this);
            return shapeParts;
        }

        /// <summary>
        /// This method must be implemented in this simple shape
        /// </summary>
        public void RenderShapeToScreen()
        {
            Console.WriteLine("Draw Line");
            // Add logic to render this shape to screen
        }
    }
}
