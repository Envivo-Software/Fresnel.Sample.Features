// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass
{
    /// <summary>
    /// This abstract object will appear in the UI, but cannot be created
    /// </summary>
    public abstract class AbstractObject
    {
        public Guid Id { get; set; }

        /// <summary>
        /// This property is hidden in the UI, and all sub-classes
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string? HiddenProperty { get; set; }

    }
}