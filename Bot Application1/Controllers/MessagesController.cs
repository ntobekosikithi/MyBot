using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;


namespace Bot_Application1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 
        static int index = 0;
        static int index2 = -1;
        public async Task<Message> Post([FromBody]Message message)
        {
            
            if (message.Type == "Message")
            {
                // calculate something for us to return
                //int length = (message.Text ?? string.Empty).Length;
                string mess = "";
                //---------------------------------------------------
                string[] questions = {
                        "There were 10 birds on a tree. A hunter shot 1. How many were left?",
                        "How do you draw a square with 3 lines?",
                        "What goes up and down, but still remains in the same place?",
                        "In Madagascar, you cannot take a picture of a lemur with gray hair. Why?",
                        "What is the smartest and quickest way to lift a giant grizzly bear with one hand?",
                        "If there are 6 apples and you take away 4, how many do you have?",
                        "What has a head and a tail but no body?",
                        "How much dirt is there in a hole 3 feet deep, 6 ft long and 4 ft wide?" };
                //--------------------------------------------
                string[] questions2 = {
                        "Megan’s Mother Has Four Daughters Named April, May, June, and What?",
                        "Why Can’t a Person Living in New York Be Buried in California?",
                        "What is brown and sticky?"
                         };
                //---------------------------------------------
                string [] answers = {
                        " 0. The rest of the birds got scared and flew away. ",
                        "You draw a square with 3 lines in the middle.",
                        "Stairs!",
                        "Don't you think you need a camera instead of gray hair to take pictures?",
                        "Well, first you would have to find a giant grizzly bear with one hand, before pondering on this question",
                        "The 4 you took.",
                        "A coin",
                        "None, or else it wouldn’t be a hole." };
                //-----------------------------------
                string[] answers2 = {
                        " Megan",
                        "because they are still alive",
                        "A stick.",
                         };

                if (message.Text=="")
                {
                    return message.CreateReplyMessage($"Please type in a message");
                }
                else if (message.Text.ToLower() == "hello" || message.Text.ToLower()== "hi")
                {
                   DateTime t1 = Convert.ToDateTime(DateTime.Now);
                   DateTime t2 = Convert.ToDateTime(("12:00 AM"));
                    index2 = -1;
                    
                    if (t1.TimeOfDay.Ticks > t2.TimeOfDay.Ticks)
                    {
                        mess = "Good afternoon" + "\r\n" + "          For a trick question with answers Please type :   trick me"+
                            "                         For trick questions with no ansawers please type:  tricked";
                        return message.CreateReplyMessage($"{mess}");

                    }
                    else
                    {
                        return message.CreateReplyMessage($"Good morning");
                    }

                }

                mess = ""; 
                if (message.Text.ToLower() == "trick me")
                {
                    mess = "";
                    

                    

                    Random rand = new Random();
                    int num = rand.Next(1,8);
                    index = num;

                    mess = questions[index] + ":                For an answer please type: Yes  ";
                    return message.CreateReplyMessage($"{mess}");
                }


                if (message.Text.ToLower()=="tricked" )
                {

                    mess = "";

                    Random rand = new Random();
                    int num = rand.Next(0, 2);
                    index = num;
                    index2 = num;
                    mess = questions2[index] + ":        type in your answwer";
                    return message.CreateReplyMessage($"{mess}");
                }

         

                if (index2>=0)
                {
                    if (index2 == 0)
                    {
                        if (message.Text.ToLower().Contains("megan") )
                        {
                            mess = "Congratulations!!! your answer is correct.....      "
                            +"           please type tricked for another question";
                            return message.CreateReplyMessage($"{mess}");
                        }
                        else
                        {
                            mess = "Wrong Answer please try again";
                            return message.CreateReplyMessage($"{mess}");
                        }
                    }
                    else if (index2 == 1)
                    {
                        if (message.Text.ToLower().Contains("alive"))
                        {
                            mess = "Congratulations!!! your answer is correct.....      "
                            + "           please type tricked for another question";
                            return message.CreateReplyMessage($"{mess}");
                        }
                        else
                        {
                            mess = "Wrong Answer please try again";
                            return message.CreateReplyMessage($"{mess}");
                        }
                    }
                    else if (index2 == 2)
                    {
                        if (message.Text.ToLower().Contains("stick"))
                        {
                            mess = "Congratulations!!! your answer is correct.....      "
                            + "           please type tricked for another question";
                            return message.CreateReplyMessage($"{mess}");
                        }
                        else
                        {
                            mess = "Wrong Answer please try again";
                            return message.CreateReplyMessage($"{mess}");
                        }
                    }
                }
                


                if (message.Text.ToLower() == "yes" || message.Text == "1")
                {
                    
                     mess = answers[index] + " for another type trick me";
                     return message.CreateReplyMessage($"{mess}");

                }

                return message.CreateReplyMessage($"Typed input not translatable!!! im sorry");
                // return our reply to the user
                //return message.CreateReplyMessage($"You sent {message.Text}");
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        public void Display(string message)
        {
            
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}