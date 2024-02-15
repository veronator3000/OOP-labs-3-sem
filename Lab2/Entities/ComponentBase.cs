using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class ComponentBase : IEquatable<ComponentBase>
{
    protected ComponentBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public bool Equals(ComponentBase? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals(obj as ComponentBase);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}