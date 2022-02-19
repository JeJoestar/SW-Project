using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    internal class GetClonesHandler : IRequestHandler<GetClones, IEnumerable<Clone>>
    {
        private IGenericRepository<Clone> _repository;

        public GetClonesHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.CloneRepository;
        }
        public async Task<IEnumerable<Clone>> Handle(GetClones request, CancellationToken cancellationToken)
            => await _repository.GetAsync(request.Filter);
    }
}
