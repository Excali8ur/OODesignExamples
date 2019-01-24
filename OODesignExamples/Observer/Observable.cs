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
            foreach (iSubscriber s in subscribers)
            {
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
}
