// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates
{
    /// <summary>
    /// This is a saveable Aggregate Root, and will appear in the UI.
    /// </summary>
    public class ExampleAggregateRoot : IAggregateRoot, IPersistable
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc/>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The name of this aggregate root
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this aggregate root
        /// </summary>
        public string? Description { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}