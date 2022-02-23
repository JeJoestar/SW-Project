// <copyright file="GetDroidByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class GetDroidByIdQuerry : IRequest<Droid>
    {
        public int DroidId { get; set; }

        public class GetDroidByIdHadler : IRequestHandler<GetDroidByIdQuerry, Droid>
        {
            private readonly IGenericRepository<Droid> _repository;

            public GetDroidByIdHadler(IUnitOfWork unitOfWork)
            {
                _repository = unitOfWork.DroidRepository;
            }

            public async Task<Droid> Handle(GetDroidByIdQuerry request, CancellationToken cancellationToken)
            {
                Droid droid = await _repository.GetByIdAsync(request.DroidId);
                return droid;
            }
        }
    }
}
