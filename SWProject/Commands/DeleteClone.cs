using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SW.DAL
{
    public class DeleteClone: IRequest<Clone>
    {
        public int Id { get; set; }
    }
}
