// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.C_Properties;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class MultiTypeChild : IValueObject
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Id { get; set; }



        /// <summary>
        /// The name of this value object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this value object
        /// </summary>
        public string Description { get; set; }
    }
}