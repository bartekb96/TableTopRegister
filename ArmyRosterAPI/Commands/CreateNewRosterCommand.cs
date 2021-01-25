using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.Commands
{
    public class CreateNewRosterCommand : IRequest<Roster>
    {
        public Roster roster { get; set; }

        public CreateNewRosterCommand(Roster _roster)
        {
            roster = _roster;
        }
    }
}
