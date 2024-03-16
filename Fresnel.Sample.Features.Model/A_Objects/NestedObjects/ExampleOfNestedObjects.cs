// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.NestedObjects
{
    public class ExampleOfNestedObjects : IAggregateRoot, IPersistable
    {
        public ExampleOfNestedObjects()
        {
            this.Level2 = new NestedLevel2
            {
                Parent = this
            };
        }

        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The name of this object
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string? Description { get; set; }

        [UI(UiRenderOption.InlineSimple)]
        [Relationship(RelationshipType.Owns)]
        [JsonInclude]
        public NestedLevel2 Level2 { get; internal set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}