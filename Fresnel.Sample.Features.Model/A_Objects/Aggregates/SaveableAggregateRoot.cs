// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates
{
    /// <summary>
    /// This is a saveable Aggregate Root. It is configured with a custom colour and icon.
    /// </summary>
    public class SaveableAggregateRoot : IAggregateRoot, IPersistable
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The name of this aggregate root
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this aggregate root
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// A collection of references to other entities
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<SaveableEntity> AssociatedEntities { get; set; } = new List<SaveableEntity>();

        /// <summary>
        /// A collection of references to other aggregates
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<AggregateReference<ExampleAggregateRoot>> AssociatedAggregates { get; set; } = new List<AggregateReference<ExampleAggregateRoot>>();

        /// <summary>
        /// A single reference to another aggregate
        /// </summary>
        /// <remarks>
        /// The JSON serialiser cannot handle interface types, hence why this property is ignored
        /// </remarks>
        [Relationship(RelationshipType.Has)]
        [JsonIgnore()]
        public IAggregateReference<ExampleAggregateRoot> SingleAssociatedAggregate { get; set; }
    }
}