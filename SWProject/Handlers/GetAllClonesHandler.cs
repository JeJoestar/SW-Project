using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class GetAllClonesHandler : IRequestHandler<GetAllClones, IEnumerable<Clone>>
    {
        private IGenericRepository<Clone> _repository;
        public GetAllClonesHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.CloneRepository;
        }

        public async Task<IEnumerable<Clone>> Handle(GetAllClones request, CancellationToken cancellationToken)
            => await _repository.GetAllAsync();
    }
}
