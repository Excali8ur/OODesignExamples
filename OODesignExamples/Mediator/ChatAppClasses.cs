using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Mediator
{
    //Mediator
    public interface iChatroom
    {
        void SendMessage(string msg, Participant user);
        void AddUser(Participant user);
        void Disconnect(Participant user);
        void ShowUsers();
        int GiveBotId();
    }

    //ConcreteMediator
    public class ChatroomImpl : iChatroom
    {
        private List<Participant> users;
        private Random r;

        public ChatroomImpl()
        {
            users = new List<Participant>();
            r = new Random();
        }

        public int GiveBotId()
        {
            return r.Next(100);
        }

        public void AddUser(Participant user)
        {
            users.Add(user);
        }

        public void Disconnect(Participant user)
        {
            users.Remove(user);
        }

        public void ShowUsers()
        {
            Console.WriteLine("*******");
            Console.WriteLine("Users in Chatroom:");
            foreach(Participant u in users)
            {
                Console.WriteLine(u.Name);
            }
            Console.WriteLine("*******");
        }

        public void SendMessage(string msg, Participant user)
        {
            foreach (Participant u in users)
            {
                //message should not be received by the user sending it
                if (u != user)
                {
                    u.Receive(user.Name, msg);
                }
            }
        }
    }

    //Collegue
    public abstract class Participant
    {
        protected iChatroom mediator;
        protected string name;
        public string Name { get => name;}

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

    //ConcreteCollegue
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

    //ConcreteCollegue
    public class Bot : Participant
    {
        public Bot(iChatroom med) : base(med)
        {
           name = "Bot " + med.GiveBotId().ToString();
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

    public class ChatClient
    {
        public void Run()
        {
            iChatroom mediator = new ChatroomImpl();
            Participant user1 = new Human(mediator, "Lisa");
            Participant user2 = new Human(mediator, "David"); 
            Participant user3 = new Bot(mediator);
            Participant user4 = new Bot(mediator);
            Participant user5 = new Bot(mediator);
            mediator.AddUser(user1);
            mediator.AddUser(user2);
            mediator.AddUser(user3);
            mediator.AddUser(user4);
            mediator.AddUser(user5);
            mediator.ShowUsers();

            user1.Send("Hi All");

            user4.Send("Bye Bye");
            user4.Disconnect();
            mediator.ShowUsers();

            user4 = new Bot(mediator);
            mediator.AddUser(user4);
            mediator.ShowUsers();
        }

    }
}
