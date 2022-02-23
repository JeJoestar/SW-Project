// <copyright file="GetCloneByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class GetCloneByIdQuerry : IRequest<Clone>
    {
        public int CloneId { get; set; }

        public class GetCloneByIdHadler : IRequestHandler<GetCloneByIdQuerry, Clone>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCloneByIdHadler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clone> Handle(GetCloneByIdQuerry request, CancellationToken cancellationToken)
            {
                Clone clone = await _unitOfWork.CloneRepository.GetByIdAsync(request.CloneId);
                return clone;
            }
        }
    }
}
