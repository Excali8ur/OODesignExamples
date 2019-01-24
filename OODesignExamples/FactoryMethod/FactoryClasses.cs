using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.FactoryMethod
{
    /// <summary>
    /// Product defines the interface for objects the factory method creates.
    /// Intentionally empty for this example.
    /// </summary>
    public interface iProduct { }

    /// <summary>
    /// Creator (also refered as Factory because it creates the Product objects) 
    /// declares the method FactoryMethod, which returns a Product object. 
    /// May call the generating method for creating Product objects.
    /// </summary>
    public abstract class Factory
    {
        public void anOperation()
        {
            iProduct product = FactoryMethod();
            //Do something with the product
        }

        protected abstract iProduct FactoryMethod();
    }

    /// <summary>
    /// ConcreteProduct implements the Product interface.
    /// Intentionally empty for this example.
    /// </summary>
    public class ConcreteProduct : iProduct { }

    /// <summary>
    /// ConcreteCreator overrides the generating method for creating ConcreteProduct objects
    /// </summary>
    public class ConcreteCreator : Factory
    {

        protected override iProduct FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }

    /// <summary>
    /// Uses the factory to create an use the factory
    /// </summary>
    public class FactoryClient
    {
        public void Run()
        {
            Factory creator = new ConcreteCreator();
            creator.anOperation();
        }
    }
}
