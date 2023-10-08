// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class MultiType
    {
        [Key]
        public Guid Id { get; set; }

        public bool A_Boolean { get; set; }

        public string A_String { get; set; }

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
        public string PropertyWithExpression => "Some value";

        /// <summary>
        /// An value object of MultiTypeChild
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public MultiTypeChild An_Object { get; set; } = new();

        /// <summary>
        /// A collection of value objects
        /// </summary>
        [AllowedOperations(canModify: false)]
        [Relationship(RelationshipType.Owns)]
        public ICollection<MultiTypeChild> A_Collection { get; set; } = new List<MultiTypeChild>();
    }
}