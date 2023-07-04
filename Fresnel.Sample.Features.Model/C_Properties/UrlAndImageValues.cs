// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of values for URLs and images
    /// </summary>
    public class UrlAndImageValues
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Allows a URL to be provided, and allows viewing in a separate window
        /// </summary>
        [UI(preferredControl: UiControlType.Url)]
        public string Custom_URL { get; set; }

        /// <summary>
        /// Allows a File to be provided, and allows viewing in a separate window
        /// </summary>
        [UI(preferredControl: UiControlType.File)]
        public string CustomFilePath { get; set; }

        /// <summary>
        /// Displays the given image file
        /// </summary>
        [UI(preferredControl: UiControlType.Image)]
        public string ImagePath { get; set; }
    }
}