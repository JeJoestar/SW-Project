// <copyright file="GetDroidByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class GetDroidByIdQuerry : IRequest<DroidDto>
    {
        public int DroidId { get; set; }

        public class GetDroidByIdHadler : IRequestHandler<GetDroidByIdQuerry, DroidDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetDroidByIdHadler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<DroidDto> Handle(GetDroidByIdQuerry request, CancellationToken cancellationToken)
            {
                Droid droid = await _unitOfWork.DroidRepository.GetByIdAsync(request.DroidId);
                DroidDto droidDto = new ()
                {
                    Model = droid.Model,
                    BaseId = droid.BaseId,
                    StarshipId = droid.StarshipId,
                    Equipment = droid.Equipment,
                };
                return droidDto;
            }
        }
    }
}
