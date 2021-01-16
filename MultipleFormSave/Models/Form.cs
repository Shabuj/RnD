using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleFormSave.Models
{
    public class Form
    {
        public Form(int formId, string formElement)
        {
            FormId = formId;
            FormElement = formElement;
        }

        public int FormId { get; set; }
        public string FormElement { get; set; }
    }
}