/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPWy.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string subjectCode { get; set; }
        
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;

            if (name == null || subjectCode == null )
                isValid = false;
            return isValid;
        }
        #endregion
    }
}