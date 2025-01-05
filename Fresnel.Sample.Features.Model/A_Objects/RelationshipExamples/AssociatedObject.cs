// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples
{
    [Visible(isVisibleInLibrary: false)]
    public class AssociatedObject : IEntity
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        public string? Property1 { get; set; }

        public int Property2 { get; set; }

        public DateTime Property3 { get; set; }
    }
}