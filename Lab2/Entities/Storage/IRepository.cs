namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public interface IRepository<T>
{
    public void Add(T component);
    public void Update(string key, T component);
    public void Delete(string key);
    public T GetComponent(string key);
}