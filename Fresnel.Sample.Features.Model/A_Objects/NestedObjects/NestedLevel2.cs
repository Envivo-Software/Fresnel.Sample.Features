// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.NestedObjects
{
    public class NestedLevel2 : IEntity
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }


        /// <summary>
        /// The name of this object
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string? Description { get; set; }

        [Relationship(RelationshipType.Owns)]
        public ICollection<NestedLevel3> Level3Items { get; private set; } = new List<NestedLevel3>();

        [Relationship(RelationshipType.OwnedBy)]
        public ExampleOfNestedObjects Parent { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}