using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class QueryView
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Experts { get; set; }
        public int QueueCount { get; set; }
        public int SubQueueCount { get; set; }
    }
}