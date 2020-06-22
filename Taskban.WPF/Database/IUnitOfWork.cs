using Taskban.WPF.Entities;
using System;

namespace Taskban.WPF.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Board> Boards { get; }
    }
}