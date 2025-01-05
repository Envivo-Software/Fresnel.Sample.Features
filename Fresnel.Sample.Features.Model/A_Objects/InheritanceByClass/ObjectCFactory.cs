// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass
{
    public class ObjectCFactory : IFactory<ObjectC>
    {
        public ObjectC Create()
        {
            var newObj = new ObjectC
            {
                Id = Guid.NewGuid(),
                A_StringValue = "This was created by the default Factory method"
            };

            return newObj;
        }

        public ObjectC Create(string stringValue)
        {
            var newObj = new ObjectC
            {
                Id = Guid.NewGuid(),
                A_StringValue = "This value was provided via the Factory method: " + stringValue
            };

            return newObj;
        }
    }
}