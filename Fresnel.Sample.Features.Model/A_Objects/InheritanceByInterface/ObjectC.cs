// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has a String and a couple of Methods
    /// </summary>
    public class ObjectC : IBaseObject
    {
        public Guid Id { get; set; }

        public string A_StringValue { get; set; }

        [Relationship(RelationshipType.Owns)]
        public IBaseObject NestedObject { get; set; }

        public void A_Method()
        {
            this.A_StringValue += "+ ";
        }

        public void A_MethodWithArgs(string value)
        {
            this.A_StringValue += $"{value} ";
        }
    }
}