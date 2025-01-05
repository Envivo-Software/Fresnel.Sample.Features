// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This class will not appear in the UI, as it cannot be constructed
    /// </summary>
    public class ExampleHiddenObject
    {
        internal ExampleHiddenObject()
        { }

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