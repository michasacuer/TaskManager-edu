namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;

    public interface IDatabaseService<T>
        where T : class
    {
        T GetItem(int id);

        IEnumerable<T> GetList();

        void Edit(T data);

        void Add(T data);

        void Remove(T data);
    }
}