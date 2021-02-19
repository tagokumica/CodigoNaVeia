using Infra.Data.Context;

namespace Infra.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CodigoNaVeiaContext _context;

        public UnitOfWork(CodigoNaVeiaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
             return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}