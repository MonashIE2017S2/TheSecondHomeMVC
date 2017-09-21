using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcPWy.Models;
using MvcPWy.HelpClass;

namespace MvcPWy.Controllers
{
    public class QuizController : ApiController
    {
        // GET: api/Student
        public IHttpActionResult Get()
        {
            IdentifyQuestionHelper helper = new IdentifyQuestionHelper();
            return Ok(helper.getAllStudents());
        }

        /*  public IEnumerable<Item> GetAllItems()
              {
                  return items;
              }
              public Item GetItemById(int id)
              {
                  var item = items.FirstOrDefault((I) => I.Id == id);
                  if (item == null)
                  {
                      throw new HttpResponseException(HttpStatusCode.NotFound);
                  }
                  return item;
              }
              public IEnumerable<Item> GetItemsByType(string type)
              {

                  return items.Where(
                      (I) => string.Equals(I.Type, type,
                          StringComparison.OrdinalIgnoreCase));
              }*/
    }
}
