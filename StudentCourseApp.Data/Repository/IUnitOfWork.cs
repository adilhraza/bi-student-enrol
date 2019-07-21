using System;
using System.Threading.Tasks;

namespace StudentCourseApp.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}