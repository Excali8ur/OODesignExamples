using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Observer
{



    public class NewsClient
    {
        public void Run()
        {
            BussinesNewsPublisher bnp = new BussinesNewsPublisher();
            SMSSubscriber sms1 = new SMSSubscriber();
            SMSSubscriber sms2 = new SMSSubscriber();
            EmailSubscriber mail = new EmailSubscriber();

            bnp.Attach(sms1);
            bnp.Attach(sms2);
            bnp.AddNews("Message1");

            bnp.Attach(mail);
            bnp.AddNews("Message2");

            bnp.Detach(sms2);
            bnp.AddNews("Message3");

            bnp.Detach(sms1);
            bnp.Detach(mail);

            bnp.AddNews("Message4");

            bnp.Attach(mail);
            bnp.AddNews("Message5");
        }
    }
}
