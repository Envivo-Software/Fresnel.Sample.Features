// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// Certain properties can only be edited when the object is new. Once it is saved, those properties become read-only.
    /// </summary>
    public class ExampleImmutableProperties : IEntity, IPersistable
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The name of this object. This becomes read-only after saving.
        /// </summary>
        [Persistence(IsImmutable = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The description for this object. This remains editable after saving.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Another editable property. This becomes read-only after saving.
        /// </summary>
        [Persistence(IsImmutable = true)]
        public DateTime? DateAndTime { get; set; } = DateTime.Now;

        /// <summary>
        /// An editable enum. This becomes read-only after saving.
        /// </summary>
        [Persistence(IsImmutable = true)]
        public CombinationOptions? EnumValues { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}