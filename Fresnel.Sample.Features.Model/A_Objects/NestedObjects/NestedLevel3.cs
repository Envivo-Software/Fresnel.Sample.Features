// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.NestedObjects
{
    public class NestedLevel3 : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string Description { get; set; }

        [Relationship(RelationshipType.Owns)]
        [JsonInclude]
        public NestedLevel4 Level4 { get; internal set; } = new NestedLevel4();

        [Relationship(RelationshipType.OwnedBy)]
        [JsonInclude]
        public NestedLevel2 Parent { get; internal set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}