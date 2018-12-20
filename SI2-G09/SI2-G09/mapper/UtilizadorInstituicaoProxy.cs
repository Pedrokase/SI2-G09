using SI2_G09.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace SI2_G09.mapper
{
    class UtilizadorInstituicaoProxy : UtilizadorInstituicao
    {

        private IContext context;
        private int? countryId;

        public UtilizadorInstituicaoProxy(UtilizadorInstituicao s, IContext ctx, int? countryId) : base()
        {
            base.Instituicao = s.Instituicao;
            base.Utilizador = s.Utilizador;
            context = ctx;
            this.countryId = countryId;
        }

        /*public override Instituicao Instituicao {
            get
            {
                if (base.Instituicao == null) //lazy load
                {
                    UtilizadorInstituicao sm = new StudentMapper(context);
                    base.Instituicao = sm.LoadCountry(this);
                }
                return base.Instituicao;
            }

            set
            {
                base.Instituicao = value;
            }
        }

        public override List<Course> EnrolledCourses
        {
            get
            {
                if (base.EnrolledCourses == null)
                {
                    StudentMapper sm = new StudentMapper(context);
                    base.EnrolledCourses = sm.LoadCourses(this);
                }
                return base.EnrolledCourses;
            }

            set
            {
                base.EnrolledCourses = value;
            }
        }*/

    }
}
