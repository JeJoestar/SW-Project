// <copyright file="DeleteCloneCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class DeleteCloneCommand : IRequest<CloneDto>
    {
        public int CloneId { get; set; }

        public class DeleteCloneHandler : IRequestHandler<DeleteCloneCommand, CloneDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCloneHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<CloneDto> Handle(DeleteCloneCommand request, CancellationToken cancellationToken)
            {
                Clone clone = await _unitOfWork.CloneRepository.DeleteAsync(request.CloneId);
                await _unitOfWork.SaveAsync();
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
