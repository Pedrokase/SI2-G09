using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SI2_G09.model;
using System.Collections.Generic;
using DAL.mapper.interfaces;

namespace SI2_G09.mapper
{
    interface IUtilizadorInstituicaoMapper : IMapper<UtilizadorInstituicao, int?, List<UtilizadorInstituicao>>
    {
    }
}
