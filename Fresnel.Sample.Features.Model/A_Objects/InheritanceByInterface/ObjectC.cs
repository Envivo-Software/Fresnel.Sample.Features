// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has a String and a couple of Methods
    /// </summary>
    public class ObjectC : IBaseObject
    {
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public long Version { get; set; }

        public string? A_StringValue { get; set; }


        /// <summary>
        /// This method modifies the String property
        /// </summary>
        public void A_Method()
        {
            this.A_StringValue += "+ ";
        }

        /// <summary>
        /// This method modifies the String property using a user-provided string
        /// </summary>
        /// <param name="value"></param>
        public void A_MethodWithArgs(string value)
        {
            this.A_StringValue += $"{value} ";
        }
    }
}