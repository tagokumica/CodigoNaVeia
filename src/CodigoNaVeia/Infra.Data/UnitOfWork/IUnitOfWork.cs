using System;

namespace Infra.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        bool Commit();
    }
}