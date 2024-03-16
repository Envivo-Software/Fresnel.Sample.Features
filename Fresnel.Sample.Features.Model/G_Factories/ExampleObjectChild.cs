// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class ExampleObjectChild : IValueObject
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this value object
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The description for this value object
        /// </summary>
        public string? Description { get; set; }

        public bool A_Boolean { get; set; }

        public string? A_String { get; set; }

        public int An_Int { get; set; }

        public double A_Double { get; set; }

        public float A_Float { get; set; }

        [DataType(DataType.Date)]
        public DateTime A_Date { get; set; }

        [DataType(DataType.DateTime)]
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
        /// The object that owns this one
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(UiRenderOption.InlineSimple)]
        public ExampleObject Parent { get; set; }
    }
}