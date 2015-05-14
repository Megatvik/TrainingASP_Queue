using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queue.Models
{
    public class EditModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool isBaned { get; set; }
    }
    public class IndexViewModel { }
}