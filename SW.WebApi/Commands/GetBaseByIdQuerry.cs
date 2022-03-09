using MediatR;

namespace SW.DAL
{
    public class GetBaseByIdQuerry : IRequest<BaseDto>
    {
        public int BaseId { get; set; }

        public class GetBaseByIdHandler : IRequestHandler<GetBaseByIdQuerry, BaseDto>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetBaseByIdHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
           
            public async Task<BaseDto> Handle(GetBaseByIdQuerry request, CancellationToken cancellationToken)
            {
                Base basee = await _unitOfWork.BaseRepository.GetByIdAsync(request.BaseId);
                if (basee is null)
                {
                    return null;
                }
                BaseDto baseDto = new ()
                {
                    AttachedFleetId = basee.AttachedFleetId,
                    AmmoSupply = basee.AmmoSupply,
                    Clones = new List<CloneDto>(),
                    Droids = new List<DroidDto>(),
                };
                var clones = _unitOfWork.CloneRepository.GetAll(clone => clone.BaseId == basee.Id);
                foreach (var clone in clones)
                {
                    baseDto.Clones.Add(new CloneDto()
                    {
                        BaseId = clone.BaseId,
                        LegionId = clone.LegionId,
                        Number = clone.Number,
                        Equipment = clone.Equipment,
                        Qualification = clone.Qualification,
                        StarshipId = clone.StarshipId,
                    });
                }
                var droids = _unitOfWork.DroidRepository.GetAll(droid => droid.BaseId == basee.Id);
                foreach (var droid in droids)
                {
                    baseDto.Droids.Add(new DroidDto()
                    {
                        BaseId = droid.BaseId,
                        Model = droid.Model,
                        Equipment = droid.Equipment,
                        StarshipId = droid.StarshipId,
                    });
                }
                return baseDto;
            }
        }

    }
}
