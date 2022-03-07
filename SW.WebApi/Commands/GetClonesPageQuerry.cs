// <copyright file="GetClonesQuerry - Copy.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using MediatR;

namespace SW.DAL
{
    public class GetClonesPageQuerry : IRequest<IEnumerable<CloneDto>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public class GetClonesPageHandler : IRequestHandler<GetClonesPageQuerry, IEnumerable<CloneDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetClonesPageHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<CloneDto>> Handle(GetClonesPageQuerry request, CancellationToken cancellationToken)
            {
                var clones = await _unitOfWork.CloneRepository.GetAsync(request.PageNumber, request.PageSize);
                var clonesDto = new List<CloneDto>();
                foreach (var clone in clones)
                {
                    clonesDto.Add(new CloneDto()
                    {
                        BaseId = clone.BaseId,
                        LegionId = clone.LegionId,
                        Number = clone.Number,
                        Equipment = clone.Equipment,
                        Qualification = clone.Qualification,
                        StarshipId = clone.StarshipId,
                    });
                }
                return clonesDto;
            }
        }
    }
}
