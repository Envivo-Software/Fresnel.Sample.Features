// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of properties with groupings
    /// </summary>
    public class GroupedValues
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is a normal Text
        /// </summary>
        [Display(GroupName = "Group 1")]
        public string Text { get; set; }

        /// <summary>
        /// This is an unformatted Date/Time.
        /// Clicking the value reveals the appropriate editor controls.
        /// </summary>
        [Display(GroupName = "Group 1")]
        public DateTime Date { get; set; }

        /// <summary>
        /// This is a normal Boolean
        /// </summary>
        [Display(GroupName = "Group 2")]
        public bool NormalBoolean { get; set; }

        /// <summary>
        /// This is a normal Number
        /// </summary>
        [Display(GroupName = "Group 2")]
        public int NormalNumber { get; set; }
    }
}