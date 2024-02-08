// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    /// <summary>
    /// This object shows how related properties are loaded immediately
    /// </summary>
    public class ObjectWithEagerLoadedProperties : IEntity
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

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
        /// This child object is loaded immediately 
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public AggregateReference<AnotherAggregateRoot> EagerLoadedChild { get; set; }

        /// <summary>
        /// These child objects are loaded and displayed immediately
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<AggregateReference<AnotherAggregateRoot>> EagerLoadedChildren { get; set; } = new List<AggregateReference<AnotherAggregateRoot>>();

        public override string ToString()
        {
            return Name;
        }
    }
}