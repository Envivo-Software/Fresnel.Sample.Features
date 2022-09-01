// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class BasicObjectFactory : IFactory<BasicObject>
    {
        /// <summary>
        /// Creates a single BasicObject
        /// </summary>
        /// <returns></returns>
        public BasicObject Create()
        {
            return new BasicObject
            {
                Name = "Created by factory"
            };
        }

        /// <summary>
        /// Creates a BasicObject, using the given parameters
        /// </summary>
        /// <param name="name">The name to be assigned</param>
        /// <param name="description">The description to be assigned</param>
        /// <returns></returns>
        public BasicObject Create(string name, string description)
        {
            return new BasicObject
            {
                Name = name,
                Description = description
            };
        }
    }
}