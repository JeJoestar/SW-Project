// <copyright file="GetBaseByIdQuerry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using MediatR;

namespace SW.DAL
{
    public class GetJediByIdQuerry : IRequest<JediDto>
    {
        public int JediId { get; set; }

        public class GetJediByIdHandler: IRequestHandler<GetJediByIdQuerry, JediDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetJediByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
           
            public async Task<JediDto> Handle(GetJediByIdQuerry request, CancellationToken cancellationToken)
            {
                Jedi jedi = await _unitOfWork.JediRepository.GetByIdAsync(request.JediId);
                if (jedi is null)
                {
                    return null;
                }
                JediDto jediDto = new ()
                {
                    LegionId = jedi.LegionId,
                    Name = jedi.Name,
                    PadawanId = jedi.PadawanId,
                    TeacherId = jedi.TeacherId,
                };
                
                return jediDto;
            }
        }
    }
}
