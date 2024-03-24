// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    /// <summary>
    /// This object shows how QuerySpecifications are used on properties
    /// </summary>
    public class ExampleUsingQuerySpecifications : IEntity
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// This property allows selection using a selection dialog, using the 'Link' button
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public SaveableEntity SingleEntityUsingDialog { get; set; }

        /// <summary>
        /// This property allows selection using a drop-down list
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        [UI(preferredControl: UiControlType.Select)]
        public SaveableEntity SingleEntityUsingSelectList { get; set; }

        /// <summary>
        /// This collection allows selections using a selection dialog, using the 'Link' button
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
        public ICollection<SaveableEntity> MultipleEntitiesUsingDialog { get; set; } = new List<SaveableEntity>();



        /// <summary>
        /// This property links to an Aggregate using a selection dialog, using the 'Link' button
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(ExampleAggregateRootQuerySpecification))]
        public IAggregateReference<ExampleAggregateRoot> SingleAggregateRefUsingDialog { get; set; }

        /// <summary>
        /// This property links to an Aggregate using a drop-down list
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(ExampleAggregateRootQuerySpecification))]
        [UI(preferredControl: UiControlType.Select)]
        public IAggregateReference<ExampleAggregateRoot> SingleAggregateRefUsingSelectList { get; set; }

        /// <summary>
        /// This collection links to Aggregates using a selection dialog, using the 'Link' button
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(ExampleAggregateRootQuerySpecification))]
        public ICollection<IAggregateReference<ExampleAggregateRoot>> MultipleAggregateRefsUsingDialog { get; set; } = new List<IAggregateReference<ExampleAggregateRoot>>();
    }
}