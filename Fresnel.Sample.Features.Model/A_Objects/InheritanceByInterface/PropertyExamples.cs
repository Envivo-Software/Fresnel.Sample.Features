// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// Shows how properties containing objects are defined
    /// </summary>
    public class PropertyExamples
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This property allows concrete objects to be created within in
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public IBaseObject OwnedObject { get; set; }

        /// <summary>
        /// This property allows existing objects of type <see cref="ObjectC"/> to be associated with it
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ObjectC AssociatedObject { get; set; }


        /// <summary>
        /// This property allows concrete objects to be created within in
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<AbstractObject> OwnedObjects { get; set; }

        /// <summary>
        /// This property allows existing objects of type <see cref="ObjectD"/> to be associated with it
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(UiRenderOption.SeparateTabExpanded)]
        public ICollection<ObjectD> AssociatedObjects { get; set; }
    }
}