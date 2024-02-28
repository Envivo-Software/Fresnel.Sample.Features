// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object is only editable when new, and becomes read-only once it's saved.
    /// </summary>
    public class ExampleValueObject : IValueObject, IPersistable
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The person's name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The person's date of birth
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}