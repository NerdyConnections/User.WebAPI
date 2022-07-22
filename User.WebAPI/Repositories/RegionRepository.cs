using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.WebAPI.Data;
using User.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace User.WebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _db;

        public RegionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Region> AddAsync(Region region)
        {
            await _db.Regions.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(int id)
        {
            var region = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region==null)
            {
                return null;

            }
            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(int id)
        {
           return  await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
        }
    }
}
