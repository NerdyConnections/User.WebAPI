﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Models;

namespace User.Domain.DTO
{
    public  class RegionDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public long Population { get; set; }

        //Navigation Property
        public IEnumerable<Walk> Walks { get; set; }
    }
}
