using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp1
{
    public class ChatUsers
    {
        public virtual int Id { get; set; }
        public virtual string Userid { get; set; }
        public virtual string password { get; set; }
        public virtual string Status { get; set; }
        public virtual string Username { get; set; }
    }
}