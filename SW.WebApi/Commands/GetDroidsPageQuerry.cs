// <copyright file="GetDroidsPageQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using MediatR;

namespace SW.DAL
{
    public class GetDroidsPageQuerry : IRequest<IEnumerable<DroidDto>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public Expression<Func<Droid, bool>> Filter { get; set; }

        public class GetDroidsPageHandler : IRequestHandler<GetDroidsPageQuerry, IEnumerable<DroidDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetDroidsPageHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<DroidDto>> Handle(GetDroidsPageQuerry request, CancellationToken cancellationToken)
            {
                var droids = await _unitOfWork.DroidRepository.GetAsync(request.PageNumber, request.PageSize, request.Filter);
                var droidsDto = new List<DroidDto>();
                foreach (var droid in droids)
                {
                    droidsDto.Add(new DroidDto()
                    {
                        BaseId = droid.BaseId,
                        Model = droid.Model,
                        Equipment = droid.Equipment,
                        StarshipId = droid.StarshipId,
                    });
                }
                return droidsDto;
            }
        }
    }
}
