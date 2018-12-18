using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using SI2_G09.model;
using DAL.mapper.interfaces;

namespace SI2_G09.mapper
{
    interface IConferenciaUtilizadorMapper : IMapper<ConferenciaUtilizador, int?, List<ConferenciaUtilizador>>
    {
    }
}
