// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of primitive Nullable properties, but all are REQUIRED.
    /// You can clear these values (as long as they have public Setters)
    /// </summary>
    public class RequiredValues : IEntity, IPersistable
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// It will be possible to clear this value, but is still mandatory.
        /// </summary>
        public bool? NullableBool { get; set; }

        /// <summary>
        /// It will be possible to clear this value, but is still mandatory.
        /// </summary>
        public int? NullableInt { get; set; }

        /// <summary>
        /// It will be possible to clear this value, but is still mandatory.
        /// </summary>
        public double? NullableDouble { get; set; }

        /// <summary>
        /// It will be possible to clear this value, but is still mandatory.
        /// </summary>
        public DateTime? NullableDateTime { get; set; }

        /// <summary>
        /// It will be possible to clear this value, but is still mandatory.
        /// </summary>
        public string NullableString { get; set; }
    }
}