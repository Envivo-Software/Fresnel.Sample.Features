using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.ValueObjects
{
    public class PayingCustomer : IAggregateRoot, IPersistable
    {
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public long Version { get; set; }

        public string Name { get; set; }

        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}
