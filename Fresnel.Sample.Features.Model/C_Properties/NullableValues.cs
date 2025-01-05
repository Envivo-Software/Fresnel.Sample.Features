// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of primitive Nullable properties.
    /// You can clear these values (as long as they have public Setters)
    /// </summary>
    public class NullableValues
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public bool? NullableBool { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public int? NullableInt { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public double? NullableDouble { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public DateTime? NullableDateTime { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public string? NullableString { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public EnumValues.IndividualOptions? NullableEnum { get; set; }

        /// <summary>
        /// It will be possible to clear this value.
        /// </summary>
        public CombinationOptions? NullableBitwiseEnum { get; set; }
    }
}