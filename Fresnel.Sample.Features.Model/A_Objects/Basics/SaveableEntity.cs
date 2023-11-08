// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This is a saveable object, and will appear in the UI.
    /// </summary>
    public class SaveableEntity : IEntity
    {
        /// <inheritdoc/>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This value should have a default value
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}