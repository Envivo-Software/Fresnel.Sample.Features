// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of Boolean properties
    /// </summary>
    public class BooleanValues
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is a normal Boolean
        /// </summary>
        public bool NormalBoolean { get; set; }

        /// <summary>
        /// This is a Boolean with custom titles
        /// </summary>
        [UI(trueValue: "Clockwise", falseValue: "Anti-Clockwise")]
        public bool Orientation { get; set; }

        /// <summary>
        /// This is a read-only Boolean
        /// </summary>
        public bool ReadOnlyBool
        {
            get { return NormalBoolean; }
        }
    }
}