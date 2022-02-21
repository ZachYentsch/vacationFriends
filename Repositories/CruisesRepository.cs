using System.Collections.Generic;
using System.Data;
using System.Linq;
using vacationFriends.Models;
using Dapper;

namespace vacationFriends.Repositories
{
    public class CruisesRepository
    {
        private readonly IDbConnection _db;
        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Cruise> getAll()
        {
            string sql = @"
            SELECT * FROM cruises;";
            List<Cruise> cruises = _db.Query<Cruise>(sql).ToList();
            return cruises;
        }

        internal Cruise getById(int id)
        {
            string sql = @"
            SELECT * FROM cruises WHERE id = @id;";
            Cruise cruise = _db.Query<Cruise>(sql, new { id }).FirstOrDefault();
            return cruise;
        }

        internal Cruise create(Cruise newCruise)
        {
            string sql = @"
            INSERT INTO cruises
            (destination, timeFrame, stops, stopName, price, type)
            Values
            (@Destination, @TimeFrame, @Stops, @StopName, @Price, @Type)
            ;
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal void edit(Cruise original)
        {
            string sql = @"
            UPDATE cruises
            SET
            destination = @Destination
            timeFrame = @TimeFrame
            stops = @Stops
            stopName = @StopName
            price = @Price
            type = @Type
            WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        internal void remove(int id)
        {
            string sql = @"
            DELETE FROM cruises WHERE id = @id LIMIT 1";
            int changed = _db.Execute(sql, new { id });
            if (changed == 0)
            {
                throw new System.Exception("Error, not deleted");
            }
        }
    }
}
