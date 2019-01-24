using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.FactoryMethod
{
    /// <summary>
    /// Product defines the interface for objects the factory method creates.
    /// </summary>
    public interface iDocument
    {
        void Open();
        void Save(string filename);
        void Close();
    }

    /// <summary>
    /// ConcreteProduct implements the Product interface.
    /// </summary>
    public class HtmlDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        {
            Console.WriteLine("HtmlDoc closed");
        }
    }

    /// <summary>
    /// ConcreteProduct implements the Product interface.
    /// </summary>
    public class MyDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        {
            Console.WriteLine("MyDoc closed");
        }
    }

    /// <summary>
    /// ConcreteProduct implements the Product interface.
    /// </summary>
    public class PdfDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        {
            Console.WriteLine("PdfDoc closed");
        }

        public string SomethingExtra()
        {
            return "Something the other docs can't do";
        }
    }


}
