using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class GetCloneByIdHadler : IRequestHandler<GetCloneById, Clone>
    {
        private IGenericRepository<Clone> _repository;

        public GetCloneByIdHadler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.CloneRepository;
        }
        
        public async Task<Clone> Handle(GetCloneById request, CancellationToken cancellationToken)
            => await _repository.GetByIdAsync(request.Id);
        
    }
}
