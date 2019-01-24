using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Mediator
{
    /// <summary>
    /// Mediator - defines an interface for communicating with Colleague objects.
    /// </summary>
    public interface iChatroom
    {
        void SendMessage(string msg, Participant user);
        void AddUser(Participant user);
        void Disconnect(Participant user);
        void ShowUsers();
    }

    /// <summary>
    /// ConcreteMediator 
    /// - Knows the colleague classes and keep a reference to the colleague objects.
    /// - Implements the communication and transfer the messages between the colleague classes.
    /// </summary>
    public class ChatroomImpl : iChatroom
    {
        private List<Participant> users;

        public ChatroomImpl()
        {
            users = new List<Participant>();
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
            foreach (Participant u in users)
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

}
