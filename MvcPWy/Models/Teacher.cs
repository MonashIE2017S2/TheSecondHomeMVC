/*
	Author: Roshan Krishnan Thirikkott
*/
using MvcPWy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcPWy.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string surName { get; set; }
        public string givenName { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public int schoolId { get; set; }
        public string emailId { get; set; }
        public string postCode { get; set; }
        [NotMapped]
        public virtual School school { get; set; }
        #region helper functions
        /*
            generate a web modell
        */
        public void generateWebModel()
        {
            MyDBContext context = new MyDBContext();
            try
            {
                this.school = context.School.FirstOrDefault(u => u.Id == this.school.Id);
            }
            catch (Exception e)
            {
                this.school = context.School.FirstOrDefault(u => u.Id == this.schoolId);
            }
        }
        #endregion

        #region validation functions
        /*
            Validate model
        */
        public bool isValid()
        {
            bool isValid = true;
            this.generateWebModel();
            if (this.school == null)
                isValid = false;
            if (surName == null || givenName == null || emailId == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}