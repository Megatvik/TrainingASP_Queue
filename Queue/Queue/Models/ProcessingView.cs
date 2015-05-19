using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class ProcessingView 
    {
        public int Expert { get; set; }
        public List<QueryView> Query { get; set; }
    }
}