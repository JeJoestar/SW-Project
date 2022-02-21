using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SW.DAL
{
    public class DeleteCloneHandler : IRequestHandler<DeleteClone, Clone>
    {
        private IGenericRepository<Clone> _repository;

        public DeleteCloneHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.CloneRepository;
        }

        public async Task<Clone> Handle(DeleteClone request, CancellationToken cancellationToken)
            => await _repository.DeleteAsync(request.Id);
        
    }
}
