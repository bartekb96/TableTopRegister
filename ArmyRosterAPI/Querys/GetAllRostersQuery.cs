using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.Querys
{
    public class GetAllRostersQuery : IRequest<List<Roster>>
    {
    }
}
