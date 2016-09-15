using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace tweetProject
{
    public class PostHub : Hub
    {
        public void SendPost(int id, string message)
        {
            Clients.All.addNewMessageToPage(id, message);
        }
        public void SendComment(int id, string message, int userid)
        {
            Clients.All.addNewMessageToPage1(id, message, userid);
        }
    }
}