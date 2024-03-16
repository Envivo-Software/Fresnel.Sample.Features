// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples.Dependencies;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    /// <summary>
    /// Examples of properties whose contents are loaded only when they are rendered.
    /// Use this technique for showing collections containing large sets of items.
    /// </summary>
    public class ExamplesOfOnDemandProperties : IEntity
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// This collection appears inline. Because it is read using a Query, the collection cannot be modified directly.
        /// Modifications may be done via the associated Method.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [RelationalQuerySpecification(typeof(AnotherAggregateRootQuerySpecification))]
        [UI(UiRenderOption.InlineExpanded)]
        public ICollection<ExampleAggregateRoot> AssociatedAndInlineExpanded { get; set; } = new List<ExampleAggregateRoot>();

        [Method(relatedPropertyName: nameof(AssociatedAndInlineExpanded))]
        public void AddAnItemHere()
        {
            var newItem = new ExampleAggregateRoot
            {
                Id = Guid.NewGuid(),
                Name = "This is added manually"
            };
            AssociatedAndInlineExpanded.Add(newItem);
        }

        /// <summary>
        /// This collection appears in a separate tab. Because it is read using a Query, the collection cannot be modified directly.
        /// Modifications may be done via the associated Method.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [RelationalQuerySpecification(typeof(AnotherAggregateRootQuerySpecification))]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<ExampleAggregateRoot> AssociatedAndSeparateTab { get; set; } = new List<ExampleAggregateRoot>();


        [Method(relatedPropertyName: nameof(AssociatedAndSeparateTab))]
        public void AddAnotherItemHere()
        {
            var newItem = new ExampleAggregateRoot
            {
                Id = Guid.NewGuid(),
                Name = "This is also added manually"
            };
            AssociatedAndSeparateTab.Add(newItem);
        }
    }
}