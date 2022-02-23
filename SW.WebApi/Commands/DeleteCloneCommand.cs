// <copyright file="DeleteCloneCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class DeleteCloneCommand : IRequest<Clone>
    {
        public int CloneId { get; set; }

        public class DeleteCloneHandler : IRequestHandler<DeleteCloneCommand, Clone>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCloneHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clone> Handle(DeleteCloneCommand request, CancellationToken cancellationToken)
            {
                Clone droid = await _unitOfWork.CloneRepository.DeleteAsync(request.CloneId);
                await _unitOfWork.SaveAsync();
                return droid;
            }
        }
    }
}
