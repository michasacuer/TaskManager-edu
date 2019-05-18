namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;

    public interface IDatabaseService<T>
        where T : class
    {
        T GetItem(int id);

        IEnumerable<T> GetList();

        T Edit(T data);

        T Add(T data);

        T Remove(T data);
    }
}