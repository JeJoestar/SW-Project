// <copyright file="InsertDroidCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
   public class InsertDroidCommand : IRequest<DroidDto>
    {
        public DroidDto DroidDto { get; set; }

        public class InsertDroidHandler : IRequestHandler<InsertDroidCommand, DroidDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertDroidHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<DroidDto> Handle(InsertDroidCommand request, CancellationToken cancellationToken)
            {
                Droid droid = new ()
                {
                    Model = request.DroidDto.Model,
                    BaseId = request.DroidDto.BaseId,
                    StarshipId = request.DroidDto.StarshipId,
                    Equipment = request.DroidDto.Equipment
                };
                await _unitOfWork.DroidRepository.InsertAsync(droid);
                await _unitOfWork.SaveAsync();
                return request.DroidDto;
            }
        }
    }
}
