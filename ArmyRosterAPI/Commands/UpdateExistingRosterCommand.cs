using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.Commands
{
    public class UpdateExistingRosterCommand : IRequest<Roster>
    {
        public Roster roster { get; set; }
        public int Id { get; set; }

        public UpdateExistingRosterCommand(Roster _roster, int _id)
        {
            roster = _roster;
            Id = _id;
        }
    }
}
