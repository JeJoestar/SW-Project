// <copyright file="DeleteDroidCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class DeleteDroidCommand : IRequest<DroidDto>
    {
        public int DroidId { get; set; }

        public class DeleteDroidHandler : IRequestHandler<DeleteDroidCommand, DroidDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteDroidHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<DroidDto> Handle(DeleteDroidCommand request, CancellationToken cancellationToken)
            {
                Droid droid = await _unitOfWork.DroidRepository.DeleteAsync(request.DroidId);
                await _unitOfWork.SaveAsync();
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
