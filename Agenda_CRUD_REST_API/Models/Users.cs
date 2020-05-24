using System;
using System.Collections.Generic;

namespace Agenda_CRUD_REST_API.Models
{
    public partial class Users
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public int? UserPhoneNumber { get; set; }
    }
}
