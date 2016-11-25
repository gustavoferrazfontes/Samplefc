using System;

namespace SampleFC.RegisterAuthentication.Core.Domain.Model
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public override bool Equals(object entity)
        {
            var entityTmp = entity as Entity;

            if (ReferenceEquals(entityTmp, null))
                return false;

            if (ReferenceEquals(this, entityTmp))
                return true;

            if (GetType() != entityTmp.GetType())
                return false;


            if (Id == 0 || entityTmp.Id == 0)
                return false;

            return Id == entityTmp.Id;
        }

        public static bool operator ==(Entity entityA, Entity entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Entity entityA, Entity entityB)
        {
            return !(entityA == entityB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
