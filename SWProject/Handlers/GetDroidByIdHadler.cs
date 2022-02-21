using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class GetDroidByIdHadler : IRequestHandler<GetDroidById, Droid>
    {
        private IGenericRepository<Droid> _repository;

        public GetDroidByIdHadler(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.DroidRepository;
        }
        
        public async Task<Droid> Handle(GetDroidById request, CancellationToken cancellationToken)
            => await _repository.GetByIdAsync(request.Id);
        
    }
}
