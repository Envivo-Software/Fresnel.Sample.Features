// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This is a saveable Aggregate Root, and will appear in the UI.
    /// </summary>
    public class SaveableAggregateRoot : IAggregateRoot, IPersistable
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The name of this aggregate root
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this aggregate root
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A collection of references to other aggregates
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<AggregateReference<SaveableEntity>> AssociatedItems { get; set; } = new List<AggregateReference<SaveableEntity>>();

        /// <summary>
        /// A single reference to another aggregate
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public AggregateReference<SaveableEntity> SingleAssociatedItem { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        IAggregateReference<T> IAggregateRoot.ToReference<T>()
        {
            return AggregateReference<T>.From(this);
        }
    }
}