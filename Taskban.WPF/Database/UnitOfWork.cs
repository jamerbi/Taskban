using LiteDB;
using Taskban.WPF.Entities;

namespace Taskban.WPF.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private const string Name = "taskban.db";
        public IRepository<Board> Boards { get; }

        //public IRepository<Task> Tasks { get; }

        //public IRepository<Settings> Settings { get; }

        private readonly ILiteDatabase _database;

        public UnitOfWork()
        {
            _database = new LiteDatabase(Name);

            Boards = new BaseRepository<Board>(_database, "Boards");
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}