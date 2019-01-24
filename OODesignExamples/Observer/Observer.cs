using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Observer
{
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
}
