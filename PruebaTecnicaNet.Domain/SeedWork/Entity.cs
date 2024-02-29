namespace PruebaTecnicaNet.Domain.SeedWork;

/// <summary>
/// Base class for entities
/// </summary>
public class Entity
{
    int? _requestedHashCode;
    int _Id;
    public virtual int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }

    // Domain Events
    private List<INotification> _domainEvents;
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    /// <summary>
    /// Check if the entity is transient
    /// </summary>
    /// <returns> True if the entity is transient, false otherwise </returns>
    public bool IsTransient()
    {
        return this.Id == default(int);
    }

    /// <summary>
    /// Check if two entities are the same
    /// </summary>
    /// <param name="obj"></param>
    /// <returns> True if the entities are the same, false otherwise </returns>
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity))
        {
            return false;
        }
        if (Object.ReferenceEquals(this, obj))
        {
            return true;
        }
        if (this.GetType() != obj.GetType())
        {
            return false;
        }
        Entity item = (Entity)obj;
        if (item.IsTransient() || this.IsTransient())
        {
            return false;
        }
        else
        {
            return item.Id == this.Id;
        }
    }

    /// <summary>
    /// Get the hash code of the entity
    /// </summary>
    /// <returns> The hash code of the entity </returns>
    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
            {
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
            }
            return _requestedHashCode.Value;
        }
        else
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Check if two entities are the same
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns> True if the entities are the same, false otherwise </returns>
    public static bool operator ==(Entity left, Entity right)
    {
        if (Object.Equals(left, null))
        {
            return (Object.Equals(right, null)) ? true : false;
        }
        else
        {
            return left.Equals(right);
        }
    }

    /// <summary>
    /// Check if two entities are different
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns> True if the entities are different, false otherwise </returns>
    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}