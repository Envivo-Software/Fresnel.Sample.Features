// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;
using Envivo.Fresnel.ModelAttributes;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// Shows how properties containing objects are defined
    /// </summary>
    public class ExamplesOfPropertiesUsingInheritance
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// This property allows concrete objects to be created within in
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public IBaseObject OwnedObject { get; set; }

        /// <summary>
        /// This property allows existing objects of type ObjectC to be associated with it
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ObjectC AssociatedObject { get; set; }


        /// <summary>
        /// This property allows concrete objects to be created within in
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<IBaseObject> OwnedObjects { get; set; } = new List<IBaseObject>();

        /// <summary>
        /// This property allows existing objects of type ObjectD to be associated with it
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<ObjectD> AssociatedObjects { get; set; } = new List<ObjectD>();
    }
}
