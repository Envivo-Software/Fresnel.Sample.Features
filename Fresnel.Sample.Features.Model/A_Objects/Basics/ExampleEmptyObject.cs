// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object has no visible properties
    /// </summary>
    public class ExampleEmptyObject : IEntity
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}