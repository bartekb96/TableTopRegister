using MediatR;
using ArmyRosterAPI.Models;


namespace ArmyRosterAPI.Commands
{
    public class DeleteExistingRosterCommand : IRequest<Roster>
    {
        public int Id { get; set; }

        public DeleteExistingRosterCommand(int _id)
        {
            Id = _id;
        }
    }
}
