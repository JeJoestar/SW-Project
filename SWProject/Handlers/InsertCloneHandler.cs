using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SW.DAL
{
    public class InsertDroidHandler : IRequestHandler<InsertDroid, Droid>
    {
        private IGenericRepository<Droid> _repository;

        public InsertDroidHandler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.DroidRepository;
        }


        public async Task<Droid> Handle(InsertDroid request, CancellationToken cancellationToken) 
            => await _repository.InsertAsync(request.Droid);
    }
}
