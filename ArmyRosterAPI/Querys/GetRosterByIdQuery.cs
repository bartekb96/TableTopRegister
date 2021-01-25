using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.Querys
{
    public class GetRosterByIdQuery : IRequest<Roster>
    {
        public int Id { get; }

        public GetRosterByIdQuery(int id)
        {
            Id = id;
        }
    }
}
