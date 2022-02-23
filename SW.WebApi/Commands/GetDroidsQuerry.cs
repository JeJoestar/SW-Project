// <copyright file="GetDroidsQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using MediatR;

namespace SW.DAL
{
    public class GetDroidsQuerry : IRequest<IEnumerable<Droid>>
    {
        public Expression<Func<Droid, bool>> Filter { get; set; }

        public class GetDroidsHandler : IRequestHandler<GetDroidsQuerry, IEnumerable<Droid>>
        {
            private readonly IGenericRepository<Droid> _repository;

            public GetDroidsHandler(IUnitOfWork unitOfWork)
            {
                _repository = unitOfWork.DroidRepository;
            }
            public async Task<IEnumerable<Droid>> Handle(GetDroidsQuerry request, CancellationToken cancellationToken)
            {
                var droids = await _repository.GetAsync(request.Filter);
                return droids;
            }
        }
    }
}
