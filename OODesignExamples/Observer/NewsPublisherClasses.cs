using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Observer
{
    /// <summary>
    /// Observable - interface or abstract class defining the operations for attaching and de-attaching observers to the client. 
    /// In the GOF book this class/interface is known as Subject.
    /// </summary>
    public abstract class NewsPublisher
    {
        private List<iSubscriber> subscribers;
        private string latestNews;
        public string LatestNews { get => latestNews; }

        public NewsPublisher()
        {
            subscribers = new List<iSubscriber>();
            latestNews = "No news yet...";
        }

        public void Attach(iSubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Detach(iSubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifyObservers()
        {
            foreach (iSubscriber s in subscribers) {
                s.Update(this);
            }
        }

        public void AddNews(string news)
        {
            latestNews = news;
            NotifyObservers();
        }
    }

    /// <summary>
    /// ConcreteObservable - concrete Observable class. 
    /// It maintains the state of the object and when a change in the state occurs it notifies the attached Observers.
    /// </summary>
    public class BussinesNewsPublisher : NewsPublisher
    {

    }

    /// <summary>
    /// Observer - interface or abstract class defining the operations to be used to notify this object.
    /// </summary>
    public interface iSubscriber
    {
        void Update(NewsPublisher np);
    }

    /// <summary>
    /// Concrete Observer implementations.
    /// </summary>
    public class SMSSubscriber : iSubscriber
    {
        public void Update(NewsPublisher np)
        {
            Console.WriteLine("SMS  Updated: " + np.LatestNews);
        }
    }

    /// <summary>
    /// Concrete Observer implementations.
    /// </summary>
    public class EmailSubscriber : iSubscriber
    {
        public void Update(NewsPublisher np)
        {
            Console.WriteLine("Mail Updated: " + np.LatestNews);
        }
    }


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
