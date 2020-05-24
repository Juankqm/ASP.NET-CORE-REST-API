using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_CRUD_REST_API.Models.ModelRequests
{
    public class EditUserRequest : UserRequest
    {
        public int ID_User { get; set; }
    }
}
