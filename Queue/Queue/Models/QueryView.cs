using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class QueryView
    {
        public int ID { get; set; }
        public string NameQuery { get; set; }
        public int ExpertsCount { get; set; }
        public int QueueCount { get; set; }
        public int SubQueueCount { get; set; }
    }
}