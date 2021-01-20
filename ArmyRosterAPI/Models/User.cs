using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyRosterAPI.Models
{
    public class User
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }
        public string City { get; set; }

        public Roster Roster { get; set; }
    }
}
