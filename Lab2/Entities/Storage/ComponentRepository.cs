using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class ComponentRepository<T> : IRepository<T>
    where T : ComponentBase
{
    private Dictionary<string, T> _component;
    public ComponentRepository()
    {
        _component = new Dictionary<string, T>();
    }

    public void Add(T component)
    {
        component = component ?? throw new ArgumentNullException(nameof(component));
        _component.Add(component.Name, component);
    }

    public void Update(string key, T component)
    {
        if (_component.ContainsKey(key))
        {
            _component[key] = component;
        }
        else
        {
            throw new ObjectNotFoundInStorageException();
        }
    }

    public void Delete(string key)
    {
        _component.Remove(key);
    }

    public T GetComponent(string key)
    {
        if (_component.TryGetValue(key, out T? component))
        {
            return component;
        }
        else
        {
            throw new ObjectNotFoundInStorageException();
        }
    }
}