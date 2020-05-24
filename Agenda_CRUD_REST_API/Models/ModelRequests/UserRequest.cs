using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_CRUD_REST_API.Models.ModelRequests
{
    public class UserRequest
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserPhoneNumber { get; set; }
    }
}
