// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.D_Enums
{
    /// <summary>
    /// A set of Enum properties
    /// </summary>
    public class EnumValues
    {
        /// <summary>
        /// This is a simple list of options.
        /// This enum is defined inside another class.
        /// </summary>
        public enum IndividualOptions
        {
            /// <summary>
            /// This is the value NONE
            /// </summary>
            None = 0,

            /// <summary>
            /// This is the value RED
            /// </summary>
            Red = 10,

            /// <summary>
            /// This is the value GREEN
            /// </summary>
            Green = 20,

            /// <summary>
            /// This is the value BLUE
            /// </summary>
            Blue = 30
        }

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This enum will be shown as a drop-down list.
        /// </summary>
        public IndividualOptions EnumValue { get; set; }

        /// <summary>
        /// This enum will be shown as a multi-choice check-list.
        /// </summary>
        public CombinationOptions EnumSwitches { get; set; }

        /// <summary>
        /// This enum will be shown as a drop-down list.
        /// The items are restricted (at run-time) using EnumValuesQuerySpecification
        /// </summary>
        [Display(GroupName = "Enum presentation")]
        [FilterQuerySpecification(typeof(EnumValuesQuerySpecification))]
        public IndividualOptions EnumValueDropDown { get; set; }

        /// <summary>
        /// This enum will be shown as a set of Radio Options
        /// </summary>
        [Display(GroupName = "Enum presentation")]
        [UI(preferredControl: UiControlType.Radio)]
        public IndividualOptions EnumRadioOptions { get; set; }
    }
}