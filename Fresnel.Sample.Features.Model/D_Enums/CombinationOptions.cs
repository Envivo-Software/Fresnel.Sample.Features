// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;

namespace Envivo.Fresnel.Sample.Features.Model.D_Enums
{
    /// <summary>
    /// This is a simple list of options.
    /// </summary>
    [Flags]
    public enum CombinationOptions
    {
        /// <summary>
        /// This is the value Eggs
        /// </summary>
        Eggs = 1,

        /// <summary>
        /// This is the value Ham
        /// </summary>
        Ham = 2,

        /// <summary>
        /// This is the value Cheese
        /// </summary>
        Cheese = 4,

        /// <summary>
        /// This is the value Spring Onions
        /// </summary>
        SpringOnions = 8,
    }
}