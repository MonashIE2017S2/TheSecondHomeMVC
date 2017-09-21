/*
	Author: Roshan Krishnan Thirikkott
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using MvcPWy.Models;

namespace MvcPWy.Models
{
    public class StudentQuality
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public string hobby { get; set; }
        public string strength { get; set; }
        public string social { get; set; }
        public string triggerPoints { get; set; }
        public string support { get; set; }
        [NotMapped]
        public virtual Student student { get; set; }
        #region helper functions
        /*
            generate a web modell
        */
        public void generateWebModel()
        {
            MyDBContext context = new MyDBContext();
            try
            {
                this.student = context.Student.FirstOrDefault(u => u.Id == this.student.Id);
            }
            catch (Exception e)
            {
                this.student = context.Student.FirstOrDefault(u => u.Id == this.studentId);
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

            if (student == null )
                isValid = false;
            return isValid;
        }
        #endregion
    }
}