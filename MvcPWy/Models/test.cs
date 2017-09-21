/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPWy.Models
{
    public class test
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string suburb { get; set; }
        public string postCode { get; set; }
        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;

            if (name == null || suburb == null || state == null)
                isValid = false;
            if (postCode == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}