// <copyright file="InsertCloneCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
   public class InsertCloneCommand : IRequest<Clone>
    {
        public Clone Clone { get; set; }

        public class InsertCloneHandler : IRequestHandler<InsertCloneCommand, Clone>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertCloneHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clone> Handle(InsertCloneCommand request, CancellationToken cancellationToken)
            {
                Clone clone = await _unitOfWork.CloneRepository.InsertAsync(request.Clone);
                await _unitOfWork.SaveAsync();
                return clone;
            }
        }
    }
}
