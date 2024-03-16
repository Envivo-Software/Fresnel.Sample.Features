// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object has multiple properties of the same type
    /// </summary>
    public class ExampleOfPropertiesOfSameType
    {

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        public ExampleBasicObject BasicObject1 { get; set; } =
            new()
            {
                Id = Guid.NewGuid(),
                Description = "This is assigned to BasicObject1"
            };

        public ExampleBasicObject BasicObject2 { get; set; } =
            new()
            {
                Id = Guid.NewGuid(),
                Description = "This is assigned to BasicObject2"
            };
    }
}