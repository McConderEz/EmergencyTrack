﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Common
{
    public abstract class Entity<TId>
        where TId: notnull
    {
        public TId Id { get; private set; }

        protected Entity() { }

        protected Entity(TId id) => Id = id;


        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TId> other)
                return false;

            if(!ReferenceEquals(this, other) || !EqualityComparer<TId>.Default.Equals(Id, other.Id)) 
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b) => !(a == b);

    }
}
