// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of properties that don't have built-in editors
    /// </summary>
    public class UnEditableValues
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is an un-editable GUID
        /// </summary>
        public Guid A_Guid_Value { get; set; }

        /// <summary>
        /// This is an un-editable Point
        /// </summary>
        public Point A_Point { get; set; }

        /// <summary>
        /// This is an un-editable KeyValuePair
        /// </summary>
        public KeyValuePair<int, string> A_Key_Value_Pair { get; set; }
    }
}