using System;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        Task<bool> SaveAsync();
    }
}
