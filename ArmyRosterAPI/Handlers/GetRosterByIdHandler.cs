using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;
using ArmyRosterAPI.Querys;
using System.Threading;
using ArmyRosterAPI.Interfaces.Repository;

namespace ArmyRosterAPI.Handlers
{
    public class GetRosterByIdHandler : IRequestHandler<GetRosterByIdQuery, Roster>
    {
        private readonly IRosterRepository _rosterRepository;

        public GetRosterByIdHandler(IRosterRepository rosterRepository)
        {
            _rosterRepository = rosterRepository;
        }

        public async Task<Roster> Handle(GetRosterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _rosterRepository.GetRosterById(request.Id);
        }
    }
}
