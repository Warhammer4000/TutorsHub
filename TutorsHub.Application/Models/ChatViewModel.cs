using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.UserModels;

namespace TutorsHub.Application.Models
{
    public class ChatViewModel
    {
        public List<User> Users { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserKey { get; set; }
        public ChatViewModel()
        {
            Users=new List<User>();
        }
    }
}