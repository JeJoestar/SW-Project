﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class GetDroids: IRequest<IEnumerable<Droid>>
    {
        public Expression<Func<Droid, bool>> Filter { get; set; } 
    }
}
