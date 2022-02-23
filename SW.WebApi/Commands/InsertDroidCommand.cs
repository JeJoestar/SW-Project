// <copyright file="InsertDroidCommand.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
   public class InsertDroidCommand : IRequest<Droid>
    {
        public Droid Droid { get; set; }

        public class InsertDroidHandler : IRequestHandler<InsertDroidCommand, Droid>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertDroidHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Droid> Handle(InsertDroidCommand request, CancellationToken cancellationToken)
            {
                Droid droid = await _unitOfWork.DroidRepository.InsertAsync(request.Droid);
                await _unitOfWork.SaveAsync();
                return droid;
            }
        }
    }
}
