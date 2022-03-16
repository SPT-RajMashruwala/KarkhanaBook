using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarKhanaBook.Model.Common
{
    public class nullstring
    {
        public List<listnullstring> listnullstrings { get; set; } = new List<listnullstring>();
    }
    public class listnullstring 
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public dynamic Data { get; set; }
    }
}
