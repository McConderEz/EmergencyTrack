﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Common
{
    public class BaseId<TId>: ValueObject where TId: notnull
    {
        public Guid Id { get; }
        protected BaseId(Guid id) => Id = id;

        public static TId NewGuid() => Create(Guid.NewGuid());
        public static TId Empty() => Create(Guid.Empty);
        public static TId Create(Guid id) => (TId)Activator.CreateInstance(typeof(TId), id)!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}
