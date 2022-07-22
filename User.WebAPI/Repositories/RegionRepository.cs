using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.WebAPI.Data;
using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _db;

        public RegionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Region> GetAll()
        {
            return _db.Regions.ToList();
        }
    }
}
