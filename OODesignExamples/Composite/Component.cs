using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Composite
{
    /// <summary>
    /// Component - Component is the abstraction for leafs and composites. 
    /// It defines the interface that must be implemented by the objects in the composition. 
    /// For example a file system resource defines move, copy, rename, and getSize methods for files and folders.
    /// 
    /// Shape is the abstraction for Lines, Rectangles (leafs) and and ComplexShapes (composites).
    /// </summary>
    public interface iShape
    {
        /// <summary>
        /// Draw shape on screen 
        /// Method that must be implemented by Basic as well as complex shapes 
        /// </summary>
        void RenderShapeToScreen();

        //Making a complex shape explode results in getting a list of the shapes forming this shape 
        //For example if a rectangle explodes it results in 4 line objects 
        //Making a simple shape explode results in returning the shape itself 

        /// <summary>
        /// Making a complex shape explode results in getting a list of the shapes forming this shape 
        /// For example if a rectangle explodes it results in 4 line objects 
        /// Making a simple shape explode results in returning the shape itself 
        /// </summary>
        /// <returns>List of all the shapes forming this shape</returns>
        List<iShape> ExplodeShape();
    }
}
