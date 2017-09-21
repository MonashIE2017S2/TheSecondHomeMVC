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
    public class Student
    {
        public int Id { get; set; }
        public string studentId { get; set; }
        public string surName { get; set; }
        public string givenName { get; set; }
        public DateTime dob { get; set; }
        public bool aboriginalOrTorres { get; set; }
        public string gender { get; set; }
        public string ethnicOrigin { get; set; }
        public string languages { get; set; }
        public string placementType { get; set; }
        public bool courtOrderGiven { get; set; }
        public string VSN { get; set; }
        public int schoolId { get; set; }
        public DateTime admissionDate { get; set; }
        public string yearLevel { get; set; }
        public bool programStuentDisability { get; set; }
        public bool deleted { get; set; }
        public string disabilityCategory { get; set; }
        public DateTime dateCurrentPlan { get; set; }
        public DateTime dateNextPlan { get; set; }
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
            if (surName == null || givenName == null || gender == null || studentId.Trim().Length == 0 )
                isValid = false;
            if (dob == null || dateCurrentPlan == null || dateNextPlan == null || admissionDate == null)
                isValid = false;
            return isValid;
        }
        #endregion
    }
}