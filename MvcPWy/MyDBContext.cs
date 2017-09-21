/*
	Author: Roshan Krishnan Thirikkott
*/
using MvcPWy.Models;
using MvcPWy.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
/*
using TheSecondHomeAPI.Auth;
*/

namespace MvcPWy
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=DefaultConnection")
        {
        }
        //public dbContext() : base() { }
        //User
        public DbSet<UserSecret> UserSecret { get; set; }
        public DbSet<UserPersonal> UserPersonal { get; set; }
        // public DbSet<UserToken> UserToken { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudentQuality> StudentQuality { get; set; }
        public DbSet<SubjectPlan> SubjectPlan { get; set; }
        public DbSet<test> test { get; set; }
        public DbSet<IdentifyQuestion> IdentifyQuestions { get; set; }
    }
}