using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.FactoryMethod
{
    /// <summary>
    /// Factory declares the method FactoryMethod, which returns a Product object. 
    /// May call the generating method for creating Product objects
    /// </summary>
    public abstract class DocFactory
    {
        /// <summary>
        /// Create new document according to the type of the document
        /// </summary>
        /// <param name="type">Type of doc to be created</param>
        /// <returns>Newly created document</returns>
        public iDocument NewDocument(string type)
        {
            iDocument myDoc = CreateDocument(type);
            myDoc.Open();

            Console.WriteLine("New doc created and openend. Type: "+ type);
            return myDoc;
        }

        /// <summary>
        /// Open a previously created document.
        /// It also creates the correct document-instance
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public iDocument OpenDocument(string filename)
        {
            string type = GetTypeFromFilename(filename);
            iDocument myDoc = CreateDocument(type);
            myDoc.Open();
            Console.WriteLine("Doc found and openend. Type: " + type);
            return myDoc;
        }

        /// <summary>
        /// Check which type of document has to be created.
        /// Note: Not implemented, it always returns type "pdf"
        /// </summary>
        /// <param name="filename">Filename with type</param>
        /// <returns></returns>
        private string GetTypeFromFilename(string filename)
        {
            return "pdf";
        }

        /// <summary>
        /// FactoryMethod
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected abstract iDocument CreateDocument(string type);
    }

    /// <summary>
    /// ConcreteCreator overrides the generating method for creating ConcreteProduct objects
    /// </summary>
    public class ConcreteDocCreator : DocFactory
    {
        /// <summary>
        /// Concrete FactoryMethod
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected override iDocument CreateDocument(string type)
        {
            switch (type.ToLower())
            {
                case "html":
                    return new HtmlDoc();
                case "docx":
                    return new MyDoc();
                case "pdf":
                    return new PdfDoc();
                default: //No concrete type found
                    return null;
            }
        }
    }
}
