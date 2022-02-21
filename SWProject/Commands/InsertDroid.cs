using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
   public class InsertClone: IRequest<Clone>
    {
        public Clone Clone { get; set; }
    }
}
