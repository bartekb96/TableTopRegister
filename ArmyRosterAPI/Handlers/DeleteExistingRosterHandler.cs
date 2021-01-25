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
    public class DeleteExistingRosterHandler : IRequestHandler<DeleteExistingRosterCommand, Roster>
    {
        private readonly IRosterRepository _rosterRepository;

        public DeleteExistingRosterHandler(IRosterRepository rosterRepository)
        {
            _rosterRepository = rosterRepository;
        }

        public async Task<Roster> Handle(DeleteExistingRosterCommand request, CancellationToken cancellationToken)
        {
            return await _rosterRepository.DeleteRoster(request.Id);
        }
    }
}
