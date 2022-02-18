using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SW.DAL
{
    public class InsertCloneHandler : IRequestHandler<InsertClone, Clone>
    {
        private IGenericRepository<Clone> _repository;

        public InsertCloneHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.CloneRepository;
        }


        public async Task<Clone> Handle(InsertClone request, CancellationToken cancellationToken) 
            => await _repository.InsertAsync(request.Clone);
    }
}
