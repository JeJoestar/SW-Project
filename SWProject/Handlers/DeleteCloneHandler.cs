using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SW.DAL
{
    public class DeleteDroidHandler : IRequestHandler<DeleteDroid, Droid>
    {
        private IGenericRepository<Droid> _repository;

        public DeleteDroidHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.DroidRepository;
        }

        public async Task<Droid> Handle(DeleteDroid request, CancellationToken cancellationToken)
            => await _repository.DeleteAsync(request.Id);
        
    }
}
