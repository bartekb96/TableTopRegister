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
    public class UpdateExistingRosterHandler : IRequestHandler<UpdateExistingRosterCommand, Roster>
    {
        private readonly IRosterRepository _rosterRepository;

        public UpdateExistingRosterHandler(IRosterRepository rosterRepository)
        {
            _rosterRepository = rosterRepository;
        }

        public async Task<Roster> Handle(UpdateExistingRosterCommand request, CancellationToken cancellationToken)
        {
            return await _rosterRepository.UpdateRoster(request.Id, request.roster);
        }
    }
}
