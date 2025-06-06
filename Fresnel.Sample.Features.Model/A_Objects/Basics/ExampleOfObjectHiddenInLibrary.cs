// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object may appear in the UI, but it is hidden in the Library panel
    /// </summary>
    [Visible(isVisibleInLibrary: false)]
    public class ExampleOfObjectHiddenInLibrary
    {
        /// <summary>
        /// The name of this object
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string? Description { get; set; }
    }
}