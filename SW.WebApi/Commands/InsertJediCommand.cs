// <copyright file="GetBaseByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class InsertJediCommand : IRequest<JediDto>
    {
        public JediDto Jedi { get; set; }

        public class InsertJediHandler : IRequestHandler<InsertJediCommand, JediDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertJediHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
           
            public async Task<JediDto> Handle(InsertJediCommand request, CancellationToken cancellationToken)
            {
                Jedi jedi = new ()
                {
                    Name = request.Jedi.Name,
                    LegionId = request.Jedi.LegionId,
                    PadawanId = request.Jedi.PadawanId,
                    TeacherId = request.Jedi.TeacherId,
                };
                await _unitOfWork.JediRepository.InsertAsync(jedi);
                await _unitOfWork.SaveAsync();
                return request.Jedi;
            }
        }
    }
}
