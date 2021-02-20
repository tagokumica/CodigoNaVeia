using Infra.Data.UnitOfWork;

namespace Application.Service
{
    public class BaseAppService
    {
        private readonly IUnitOfWork _uow;


        public BaseAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}