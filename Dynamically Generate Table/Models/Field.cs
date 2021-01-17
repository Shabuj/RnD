using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class Field
    {
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int TableId { get; set; }
        public int TableFieldId { get; set; }

        public Table Table { get; set; }

    }
}