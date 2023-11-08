// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    /// <summary>
    /// This object shows how QuerySpecifications are used on properties
    /// </summary>
    public class PropertiesUsingQuerySpecifications : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// This object will open a selection dialog
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public SaveableEntity SingleEntityUsingDialog { get; set; }

        /// <summary>
        /// This object will open a selection list
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        [UI(preferredControl: UiControlType.Select)]
        public SaveableEntity SingleEntityUsingSelectList { get; set; }

        /// <summary>
        /// This collection will open a selection dialog
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public ICollection<SaveableEntity> MultipleEntitiesUsingDialog { get; set; } = new List<SaveableEntity>();



        /// <summary>
        /// This object will open a selection dialog
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public IAggregateReference<AnotherAggregateRoot> SingleAggregateRefUsingDialog { get; set; }

        /// <summary>
        /// This object will open a selection list
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        [UI(preferredControl: UiControlType.Select)]
        public IAggregateReference<AnotherAggregateRoot> SingleAggregateRefUsingSelectList { get; set; }

        /// <summary>
        /// This collection will open a selection dialog
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public ICollection<IAggregateReference<AnotherAggregateRoot>> MultipleAggregateRefsUsingDialog { get; set; } = new List<IAggregateReference<AnotherAggregateRoot>>();
    }
}