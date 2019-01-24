using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Mediator
{
    /// <summary>
    /// Colleague classes 
    /// - Keep a reference to its Mediator object.
    /// - Communicates with the Mediator whenever it would have otherwise communicated with another Colleague.
    /// </summary>
    public abstract class Participant
    {
        protected iChatroom mediator;
        protected string name;
        public string Name { get => name; }

        public Participant(iChatroom med)
        {
            mediator = med;
            name = "None";
        }

        public abstract void Send(string msg);
        public abstract void Receive(string receivedFrom, string msg);

        public void Disconnect()
        {
            mediator.Disconnect(this);
            mediator = null;
        }
    }

    /// <summary>
    /// ConcreteCollegue
    /// </summary>
    public class Human : Participant
    {
        public Human(iChatroom med, string name) : base(med)
        {
            this.name = name;
        }

        public override void Send(string msg)
        {
            Console.WriteLine(name + " sending = " + msg);
            mediator.SendMessage(msg, this);
        }

        public override void Receive(string receivedFrom, string msg)
        {
            Console.WriteLine(receivedFrom + "->" + name + ": " + msg);
        }
    }

    /// <summary>
    /// ConcreteCollegue
    /// </summary>
    public class Bot : Participant
    {
        public Bot(iChatroom med, int id) : base(med)
        {            
            name = "Bot " + id.ToString();
        }

        public override void Send(string msg)
        {
            Console.WriteLine(name + " sending : " + msg);
            mediator.SendMessage(msg, this);
        }

        public override void Receive(string receivedFrom, string msg)
        {
            Console.WriteLine(receivedFrom + "->" + name + ": " + msg);
            if (receivedFrom.Substring(0, 3) != "Bot")
            {
                Console.WriteLine("Received msg from a human");
            }
        }
    }
}
