using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArmyRosterAPI.Models
{
    public class Roster
    {
        public int Id { get; set; }
        public int UserId { get; set; }     

        public User User { get; set; }
        public string ArmyName { get; set; }   
    }
}
