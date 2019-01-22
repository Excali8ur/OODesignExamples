using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.FactoryMethod
{
    public interface iDocument
    {
        void Open();
        void Save(string filename);
        void Close();
    }

    public class HtmlDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        { }
    }

    public class MyDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        { }
    }

    public class PdfDoc : iDocument
    {
        public void Open()
        { }
        public void Save(string filename)
        { }
        public void Close()
        { }
    }

    public abstract class DocApp
    {
        private List<iDocument> docs = new List<iDocument>();

        public void NewDocument(string type)
        {
            iDocument myDoc = CreateDocument(type);
            docs.Add(myDoc);
            myDoc.Open();

        }
        public void OpenDocument(string filename)
        {
            string type = GetTypeFromFilename(filename);
            iDocument myDoc = CreateDocument(type);
            docs.Add(myDoc);
            myDoc.Open();
        }

        public void CloseAllDocuments()
        {
            foreach(iDocument d in docs)
            {
                d.Close();
            }
        }

        private string GetTypeFromFilename(string filename)
        {
            return "pdf";
        }
        protected abstract iDocument CreateDocument(string type);
    }

    public class ConcreteDocCreator : DocApp
    {
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

        protected iProduct FactoryMethod()
        {
            return new ConcreteProduct();
        }
    }

    public class DocClient
    {
        public void Run()
        {
            DocApp creator = new ConcreteDocCreator();
            creator.NewDocument("pdf");
            creator.NewDocument("docx");
            creator.OpenDocument("D:\\test.docx");
        }
    }
}
