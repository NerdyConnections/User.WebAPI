﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Models
{
    public  class Region
    {
          public int Id { get; set; }

        public string  Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public long Population { get; set; }

        //Navigation Property
        public IEnumerable<Walk> Walks { get; set; }
    }
}
