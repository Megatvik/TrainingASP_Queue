using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class QueueView
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public int WaitingTime { get; set; }
        public bool IsSubQueue { get; set; }
    }
}