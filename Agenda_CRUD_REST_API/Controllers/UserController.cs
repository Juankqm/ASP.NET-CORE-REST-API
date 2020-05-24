using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda_CRUD_REST_API.Models;
using Agenda_CRUD_REST_API.Models.ModelRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace Agenda_CRUD_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (AgendaAPIContext DB = new AgendaAPIContext())
            {
                var lst = (from c in DB.Users
                          select c).ToList();
                return Ok(lst);
            }
        }

        [HttpPost]
        public ActionResult Post( [ FromBody] UserRequest User)
        {
            using (AgendaAPIContext DB = new AgendaAPIContext())
            {
                Users oUser = new Users();

                oUser.Name = User.UserName;
                oUser.UserEmail = User.UserEmail;
                oUser.UserPhoneNumber = User.UserPhoneNumber;

                DB.Users.Add(oUser); //Such as INSERT QUery in SQLServer
                DB.SaveChanges(); //Such as EXECUTE in SQLServer

                ////Verification
                //if (DB.SaveChanges() == 1)
                //{
                //    //add Positive Message
                //}else
                //{
                //    //add Negative Message
                //}

            }
            return Ok();
        }

        [HttpPut]

        public ActionResult Put( [ FromBody ] EditUserRequest User)
        {
            using (AgendaAPIContext DB = new AgendaAPIContext())
            {
                Users oUser = DB.Users.Find(User.ID_User);

                oUser.Name = User.UserName;
                oUser.UserEmail = User.UserEmail;
                oUser.UserPhoneNumber = User.UserPhoneNumber;

                DB.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DB.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete( [FromBody] EditUserRequest User )
        {
            using ( AgendaAPIContext DB = new AgendaAPIContext())
            {
                Users oUser = DB.Users.Find(User.ID_User);
                DB.Users.Remove(oUser);
                DB.SaveChanges();

                //try
                //{
                //    if (DB.SaveChanges() == 1)
                //    {
                //        //Object deleted successfully
                //    }
                //}
                //catch (Exception)
                //{
                //    //Something was wrong and the object was not deleted
                //}
            }
            //return a Json File
            return Ok();
        }
    }
}