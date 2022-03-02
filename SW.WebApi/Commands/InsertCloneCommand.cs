// <copyright file="InsertCloneCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
   public class InsertCloneCommand : IRequest<CloneDto>
    {
        public CloneDto CloneDto { get; set; }

        public class InsertCloneHandler : IRequestHandler<InsertCloneCommand, CloneDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertCloneHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CloneDto> Handle(InsertCloneCommand request, CancellationToken cancellationToken)
            {
                Clone clone = new ()
                {
                    Number = request.CloneDto.Number,
                    LegionId = request.CloneDto.LegionId,
                    BaseId = request.CloneDto.BaseId,
                    StarshipId = request.CloneDto.StarshipId,
                    Equipment = request.CloneDto.Equipment,
                    Qualification = request.CloneDto.Qualification,
                };
                await _unitOfWork.CloneRepository.InsertAsync(clone);
                await _unitOfWork.SaveAsync();
                return request.CloneDto;
            }
        }
    }
}
