﻿using DAL.mapper.interfaces;
using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.mapper
{
    interface IUtilizadorMapper : IMapper<Utilizador, int?, List<Utilizador>>
    {
    }
}
