using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODesignExamples.Mediator
{
    public class ChatClient
    {
        public void Run()
        {
            Random r = new Random();
            iChatroom mediator = new ChatroomImpl();
            Participant user1 = new Bot(mediator, r.Next(100));
            Participant user2 = new Human(mediator, "Lisa");
            Participant user3 = new Bot(mediator, r.Next(100));
            Participant user4 = new Human(mediator, "David");             
            Participant user5 = new Bot(mediator, r.Next(100));
            mediator.AddUser(user1);
            mediator.AddUser(user2);
            mediator.AddUser(user3);
            mediator.AddUser(user4);
            mediator.AddUser(user5);
            mediator.ShowUsers();

            user1.Send("Hi All");

            user3.Send("Bye Bye");
            user3.Disconnect();
            mediator.ShowUsers();

            user3 = new Bot(mediator, r.Next(DateTime.Now.Millisecond));
            mediator.AddUser(user3);
            mediator.ShowUsers();
        }
    }
}
