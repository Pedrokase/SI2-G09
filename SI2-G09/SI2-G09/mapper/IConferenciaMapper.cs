
using System.Collections.Generic;
using SI2_G09.model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.mapper.interfaces;

namespace SI2_G09.mapper
{
    interface IConferenciaMapper : IMapper<Conferencia, int?, List<Conferencia>>
    {
    }
}
