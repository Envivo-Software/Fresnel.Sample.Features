// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    /// <summary>
    /// This object shows how related properties are loaded immediately
    /// </summary>
    public class ExamplesOfEagerLoadedProperties : IEntity, IPersistable
    {
        public ExamplesOfEagerLoadedProperties()
        {
            this.OwnedObject = new OwnedObject
            {
                Id = Guid.NewGuid(),
                Property1 = "This should be visible immediately",
                Property2 = 12345,
                Property3 = DateTime.Parse("2024/01/01")
            };
        }

        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        /// <inheritdoc/>
        public long Version { get; set; }

        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This value should have a default value
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// This child object is loaded and displayed immediately
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public AggregateReference<ExampleAggregateRoot> EagerLoadedChild { get; set; }

        /// <summary>
        /// This child Value Object is loaded and displayed immediately
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ExampleValueObject EagerLoadedValueObject { get; set; } = new();

        /// <summary>
        /// These child objects are loaded and displayed immediately
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<AggregateReference<ExampleAggregateRoot>> EagerLoadedChildren { get; set; } = new List<AggregateReference<ExampleAggregateRoot>>();

        /// <summary>
        /// This child object is loaded immediately, even though it's only displayed when the tab is selected
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.SeparateTabExpanded)]
        public OwnedObject OwnedObject { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}