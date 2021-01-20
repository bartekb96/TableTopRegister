using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmyRosterAPI.Models;

namespace ArmyRosterAPI.Interfaces.Repository
{
    public interface IRosterRepository
    {
        public Task<List<Roster>> GetAllRosters();
        public Task<Roster> GetRosterById(int id);
        public Task<Roster> CreateRoster(Roster roster);
        public Task<Roster> UpdateRoster(int id, Roster roster);
        public Task<Roster> DeleteRoster(int id);
    }
}
