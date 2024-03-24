// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class BasicObjectFactory : IFactory<ExampleBasicObject>
    {
        /// <summary>
        /// Creates a single BasicObject
        /// </summary>
        /// <returns></returns>
        public ExampleBasicObject Create()
        {
            return new ExampleBasicObject
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
        public ExampleBasicObject Create(string name, string description)
        {
            return new ExampleBasicObject
            {
                Name = name,
                Description = description
            };
        }
    }
}