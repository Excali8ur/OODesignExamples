using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.FactoryMethod
{
    public class DocClient
    {
        private List<iDocument> docs = new List<iDocument>();

        public void Run()
        {
            DocFactory creator = new ConcreteDocCreator();
            iDocument myDoc = creator.NewDocument("pdf");
            docs.Add(myDoc);

            myDoc = creator.NewDocument("docx");
            docs.Add(myDoc);

            myDoc = creator.OpenDocument("D:\\test.docx");
            docs.Add(myDoc);

            CloseAllDocuments();
        }

        public void CloseAllDocuments()
        {
            foreach (iDocument d in docs)
            {         
                //Do something if the doc is a pdf
                //Note: If a lot of this is in your code, reconsider using the factory-pattern
                if (d is PdfDoc)
                {
                    Console.WriteLine(((PdfDoc)d).SomethingExtra());
                }
                d.Close();
            }
        }
    }
}
