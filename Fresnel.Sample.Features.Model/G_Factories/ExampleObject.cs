// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    /// <summary>
    /// This object is created by it's associated Factory
    /// </summary>
    public class ExampleObject
    {
        [Key]
        public Guid Id { get; set; }

        public bool A_Boolean { get; set; }

        public string? A_String { get; set; }

        public int An_Int { get; set; }

        public double A_Double { get; set; }

        public float A_Float { get; set; }

        public DateTime A_DateTime { get; set; }

        /// <summary>
        /// This Enum only allows one option
        /// </summary>
        public EnumValues.IndividualOptions An_Enum { get; set; }

        /// <summary>
        /// This Enum allows multiple options 
        /// </summary>
        public CombinationOptions A_Bitwise_Enum { get; set; }

        /// <summary>
        /// This property uses expression syntax
        /// </summary>
        public string? PropertyWithExpression => "Some value";

        /// <summary>
        /// A child value object
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public ExampleObjectChild An_Object { get; set; } = new();

        /// <summary>
        /// A collection of value objects
        /// </summary>
        [AllowedOperations(canModify: false)]
        [Relationship(RelationshipType.Owns)]
        public ICollection<ExampleObjectChild> A_Collection { get; set; } = new List<ExampleObjectChild>();
    }
}