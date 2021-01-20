using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Querys;
using ArmyRosterAPI.Models;
using System.Threading;
using ArmyRosterAPI.Interfaces.Repository;

namespace ArmyRosterAPI.Handlers
{
    public class GeAllRostersHandler : IRequestHandler<GetAllRostersQuery, List<Roster>>
    {
        private readonly IRosterRepository _rosterRepository;

        public GeAllRostersHandler(IRosterRepository rosterRepository)
        {
            _rosterRepository = rosterRepository;
        }

        public async Task<List<Roster>> Handle(GetAllRostersQuery request, CancellationToken cancellationToken)
        {
            return await _rosterRepository.GetAllRosters();
        }
    }
}
