// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples.Dependencies;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    /// <summary>
    /// Examples of properties whose contents are loaded only when they are rendered.
    /// Use this technique for showing collections containing large sets of items.
    /// </summary>
    public class PropertiesLoadedOnDemand : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ths object appears inline, and only allows the association of existing objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [RelationalQuerySpecification(typeof(AnotherAggregateRootQuerySpecification))]
        [UI(UiRenderOption.InlineSimple)]
        public ICollection<AnotherAggregateRoot> AssociatedAndInlineSimple { get; set; } = new List<AnotherAggregateRoot>();

        /// <summary>
        /// Ths object appears inline, and only allows the association of existing objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [RelationalQuerySpecification(typeof(AnotherAggregateRootQuerySpecification))]
        [UI(UiRenderOption.InlineExpanded)]
        public ICollection<AnotherAggregateRoot> AssociatedAndInlineExpanded { get; set; } = new List<AnotherAggregateRoot>();

        /// <summary>
        /// Ths object appears iin a separate tab, and only allows the association of existing objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [RelationalQuerySpecification(typeof(AnotherAggregateRootQuerySpecification))]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<AnotherAggregateRoot> AssociatedAndSeparateTab { get; set; } = new List<AnotherAggregateRoot>();
    }
}