using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Models
{
    public class Walk
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public double Length { get; set; }

        public int RegionId { get; set; }
        public int WalkDifficultyId { get; set; }


        //Navigation Property
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
