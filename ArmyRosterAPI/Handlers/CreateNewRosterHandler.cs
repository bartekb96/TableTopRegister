using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ArmyRosterAPI.Models;
using ArmyRosterAPI.Commands;
using System.Threading;
using ArmyRosterAPI.Interfaces.Repository;

namespace ArmyRosterAPI.Handlers
{
    public class CreateNewRosterHandler : IRequestHandler<CreateNewRosterCommand, Roster>
    {
        private readonly IRosterRepository _rosterRepository;

        public CreateNewRosterHandler(IRosterRepository rosterRepository)
        {
            _rosterRepository = rosterRepository;
        }

        public async Task<Roster> Handle(CreateNewRosterCommand request, CancellationToken cancellationToken)
        {
            return await _rosterRepository.CreateRoster(request.roster);
        }
    }
}
