// <copyright file="GetClonesQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using MediatR;

namespace SW.DAL
{
    public class GetClonesQuerry : IRequest<IEnumerable<Clone>>
    {
        public Expression<Func<Clone, bool>> Filter { get; set; }

        public class GetClonesHandler : IRequestHandler<GetClonesQuerry, IEnumerable<Clone>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetClonesHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<Clone>> Handle(GetClonesQuerry request, CancellationToken cancellationToken)
            {
                var clones = await _unitOfWork.CloneRepository.GetAsync(request.Filter);
                return clones;
            }
        }
    }
}
