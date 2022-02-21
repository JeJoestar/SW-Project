using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    internal class GetDroidsHandler : IRequestHandler<GetDroids, IEnumerable<Droid>>
    {
        private IGenericRepository<Droid> _repository;

        public GetDroidsHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.DroidRepository;
        }
        public async Task<IEnumerable<Droid>> Handle(GetDroids request, CancellationToken cancellationToken)
            => await _repository.GetAsync(request.Filter);
    }
}
