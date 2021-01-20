using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmyRosterAPI.AccessDataBases;
using ArmyRosterAPI.Interfaces.Repository;
using ArmyRosterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmyRosterAPI.Repository
{
    public class RosterRepository : IRosterRepository
    {
        private readonly ArmyRosterContext _context;

        public RosterRepository(ArmyRosterContext context)
        {
            _context = context;
        }

        public async Task<Roster> CreateRoster(Roster roster)
        {
            var result = await _context.Rosters.AddAsync(roster);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Roster> DeleteRoster(int Id)
        {
            var roster = await _context.Rosters.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == Id);

            if (roster != null)
            {
                _context.Rosters.Remove(roster);

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == roster.UserId);
                if (user != null)
                    _context.Users.Remove(user);

                await _context.SaveChangesAsync();
                return roster;

                _context.SaveChanges();
            }

            return null;
        }

        public async Task<List<Roster>> GetAllRosters()
        {
            return await _context.Rosters.Include(r => r.User).ToListAsync();
        }

        public async Task<Roster> GetRosterById(int id)
        {
            return await _context.Rosters.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Roster> UpdateRoster(int id, Roster roster)
        {
            var result = await _context.Rosters.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == roster.Id);
            
            if (result != null)
            {
                result.ArmyName = roster.ArmyName;

                result.User.City = roster.User.City;
                result.User.Email = roster.User.Email;
                result.User.FirstName = roster.User.FirstName;
                result.User.SecondName = roster.User.SecondName;

                _context.Rosters.Update(result);

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
