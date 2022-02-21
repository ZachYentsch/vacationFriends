using System;
using System.Collections.Generic;
using vacationFriends.Models;
using vacationFriends.Repositories;

namespace vacationFriends.Services
{
    public class CruisesService
    {
        private readonly CruisesRepository _repo;
        public CruisesService(CruisesRepository repo)
        {
            _repo = repo;
        }

        internal List<Cruise> getAll()
        {
            List<Cruise> cruises = _repo.getAll();
            return cruises;
        }

        internal Cruise getById(int id)
        {
            Cruise cruise = _repo.getById(id);
            if (cruise == null)
            {
                throw new Exception("Invalid Id");
            }
            return cruise;
        }

        internal Cruise create(Cruise newCruise)
        {
            Cruise cruise = _repo.create(newCruise);
            return cruise;
        }

        internal Cruise edit(Cruise update)
        {
            Cruise original = getById(update.Id);
            original.Destination = update.Destination != null ? update.Destination : original.Destination;
            original.Price = update.Price != 0 ? update.Price : original.Price;
            original.Stops = update.Stops != 0 ? update.Stops : original.Stops;
            original.StopName = update.StopName != null ? update.StopName : original.StopName;
            original.TimeFrame = update.TimeFrame != null ? update.TimeFrame : original.TimeFrame;
            _repo.edit(original);
            return original;
        }

        internal void remove(int id)
        {
            getById(id);
            _repo.remove(id);
        }
    }
}