﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public interface  IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

    }
}
