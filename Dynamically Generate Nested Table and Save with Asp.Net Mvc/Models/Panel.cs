using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Panel
    {
        public int PanelId { get; set; }
        public int PanelRow { get; set; }
        public int PanelCol { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}