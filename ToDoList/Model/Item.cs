using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model
{
    internal class Item
    {
        public string Task { get; set; }
        public string Place {  get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
    }
}
