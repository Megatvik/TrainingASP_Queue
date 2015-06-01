using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class ExpertView
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsWorking { get; set; }
        public List<QueryView> ProcessingQuery { get; set; }          
    }
}