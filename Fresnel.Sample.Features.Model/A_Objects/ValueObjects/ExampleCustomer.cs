using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.ValueObjects
{
    /// <summary>
    /// This object has a collection of Value Objects.
    /// The Value Objects are only editable until this object is saved.
    /// </summary>
    public class ExampleCustomer : IAggregateRoot, IPersistable
    {
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public long Version { get; set; }

        public string? Name { get; set; }

        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}
