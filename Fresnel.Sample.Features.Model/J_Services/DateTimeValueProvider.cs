// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.J_Services
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class DateTimeValueProvider : IValueProvider<object, DateTime>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public DateTime GetValue(object context)
        {
            return DateTime.Now;
        }
    }
}