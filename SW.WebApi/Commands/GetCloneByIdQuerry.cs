// <copyright file="GetCloneByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class GetCloneByIdQuerry : IRequest<CloneDto>
    {
        public int CloneId { get; set; }

        public class GetCloneByIdHadler : IRequestHandler<GetCloneByIdQuerry, CloneDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetCloneByIdHadler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CloneDto> Handle(GetCloneByIdQuerry request, CancellationToken cancellationToken)
            {
                Clone clone = await _unitOfWork.CloneRepository.GetByIdAsync(request.CloneId);
                CloneDto cloneDto = new ()
                {
                    BaseId = clone.BaseId,
                    StarshipId = clone.StarshipId,
                    LegionId = clone.LegionId,
                    Number = clone.Number,
                    Equipment = clone.Equipment,
                    Qualification = clone.Qualification,
                };
                return cloneDto;
            }
        }
    }
}
