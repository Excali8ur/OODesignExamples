using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Composite
{
    //Shape is the Component interface
    public interface iShape
    {

        //Draw shape on screen 
        //Method that must be implemented by Basic as well as complex shapes 
        void RenderShapeToScreen();

        //Making a complex shape explode results in getting a list of the shapes forming this shape 
        //For example if a rectangle explodes it results in 4 line objects 
        //Making a simple shape explode results in returning the shape itself 
        List<iShape> ExplodeShape();
    }

    //Line is a basic shape that does not support adding shapes
    public class Line : iShape
    {


        //Create a line between point1 and point2
        public Line(int point1X, int point1Y, int point2X, int point2Y)
        {

        }

        public List<iShape> ExplodeShape()
        {
            // making a simple shape explode would return only the shape itself, there are no parts of this shape
            List<iShape> shapeParts = new List<iShape>();
            shapeParts.Add(this);
            return shapeParts;

        }

        //This method must be implemented in this simple shape
        public void RenderShapeToScreen()
        {
            Console.WriteLine("Draw Shape");
            // logic to render this shape to screen
        }

    }

    //Rectangle is a composite 
    //Complex Shape
    public class Rectangle : iShape
    {
        // List of shapes forming the rectangle
        // rectangle is centered around origin
        List<iShape> rectangleEdges;
        public Rectangle()
        {
            rectangleEdges = new List<iShape>();
            rectangleEdges.Add(new Line(-1, -1,  1, -1));
            rectangleEdges.Add(new Line(-1,  1,  1,  1));
            rectangleEdges.Add(new Line(-1, -1, -1,  1));
            rectangleEdges.Add(new Line( 1, -1,  1,  1));
        }

        public List<iShape> ExplodeShape()
        {
            return rectangleEdges;
        }

        //this method is implemented directly in basic shapes 
        //in complex shapes this method is implemented using delegation
        public void RenderShapeToScreen()
        {
            foreach (iShape s in rectangleEdges)
            {
                // delegate to child objects
                s.RenderShapeToScreen();
            }
        }
    }

    //Composite object supporting creation of more complex shapes Complex Shape
    public class ComplexShape : iShape
    {
        //List of shapes 
        List<iShape> shapeList = new List<iShape>();

        public void AddToShape(iShape shapeToAddToCurrentShape)
        {
            shapeList.Add(shapeToAddToCurrentShape);
        }

        public List<iShape> ExplodeShape()
        {
            return shapeList;
        }

        //this method is implemented directly in basic shapes 
        //in complex shapes this method is handled with delegation
        public void RenderShapeToScreen()
        {
            foreach (iShape s in shapeList)
            {
                // use delegation to handle this method
                s.RenderShapeToScreen();
            }
        }
    }

    //Driver Class
    public class GraphicsEditor
    {

        public static void main(String[] args)
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

