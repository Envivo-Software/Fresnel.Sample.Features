// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    public class ExamplesOfRelationships : IEntity
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// This object will appear on a separate tab, and is not editable inline.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        public AssociatedObject NoRelationshipAndInlineSimple { get; set; } = new();

        /// <summary>
        /// Ths object appears as a single line, and only allows the creation of new objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.InlineSimple)]
        public OwnedObject OwnedAndInlineSimple { get; set; } = new();

        /// <summary>
        /// Ths object appears inline, and only allows the creation of new objects.
        /// Editing may be performed inline, or in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.InlineExpanded)]
        public OwnedObject OwnedAndInlineExpanded { get; set; } = new();

        /// <summary>
        /// Ths object appears inline, and only allows the association of existing objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.InlineSimple)]
        public AssociatedObject AssociatedAndInlineSimple { get; set; } = new();

        /// <summary>
        /// Ths object appears inline, and only allows the association of existing objects.
        /// Editing must be done by opening in a separate explorer.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.InlineExpanded)]
        public AssociatedObject AssociatedAndInlineExpanded { get; set; } = new();
    }
}