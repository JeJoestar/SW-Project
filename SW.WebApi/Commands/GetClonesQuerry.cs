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
            private readonly IGenericRepository<Clone> _repository;

            public GetClonesHandler(IUnitOfWork unitOfWork)
            {
                _repository = unitOfWork.CloneRepository;
            }
            public async Task<IEnumerable<Clone>> Handle(GetClonesQuerry request, CancellationToken cancellationToken)
            {
                var clones = await _repository.GetAsync(request.Filter);
                return clones;
            }
        }
    }
}
