using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RND.Models
{
    public class TableViewModel
    {     
        public int TableId { get; set; }
        public string TableName { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public int TableFieldId { get; set; }
        public TableViewModel(int tableId, string tableName, int fieldId, string fieldName, string fieldtype, int tableFieldId)
        {
            TableId = tableId;
            TableName = tableName;
            FieldId = fieldId;
            FieldName = fieldName;
            FieldType = fieldtype;
            TableFieldId = tableFieldId;
        }
    }
}