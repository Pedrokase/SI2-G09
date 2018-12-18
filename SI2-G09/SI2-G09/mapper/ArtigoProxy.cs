using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2_G09.mapper
{
    class ArtigoProxy
    {
        private IContext context;
        public ArtigoProxy(Course c, IContext ctx) : base()
        {
            context = ctx;

            base.Id = c.Id;
            base.Name = c.Name;
            base.EnrolledStudents = null;
        }
        public override List<Student> EnrolledStudents
        {
            get
            {
                if (base.EnrolledStudents == null)//lazy load
                {
                    CourseMapper cm = new CourseMapper(context);
                    base.EnrolledStudents = cm.LoadStudents(this);
                }
                return base.EnrolledStudents;
            }

            set
            {
                base.EnrolledStudents = value;
            }
        }
    }
}
