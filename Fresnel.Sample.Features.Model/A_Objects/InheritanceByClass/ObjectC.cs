// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass
{
    /// <summary>
    /// This object has a String and a couple of Methods
    /// </summary>
    public class ObjectC : AbstractObject
    {
        public string A_StringValue { get; set; }

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