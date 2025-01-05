// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
   
    public class ExampleObjectFactory : IFactory<ExampleObject>
    {
        /// <summary>
        /// Creates a single ExampleObject
        /// </summary>
        /// <returns></returns>
        public ExampleObject Create()
        {
            return Create(5);
        }

        /// <summary>
        /// Creates a single ExampleObject, but with 'n' items in it's collection
        /// </summary>
        /// <param name="itemCount">The number of items to add to the collection</param>
        /// <returns></returns>
        public ExampleObject Create(int itemCount)
        {
            var newObj = new ExampleObject
            {
                Id = Guid.NewGuid(),
                A_DateTime = DateTime.Now,
                A_String = $"Created by {this.GetType().Name}"
            };

            for (var i = 0; i < itemCount; i++)
            {
                newObj.A_Collection.Add(new ExampleObjectChild
                {
                    Id = Guid.NewGuid(),
                    Name = $"Item no {i}",
                    Description = $"Created by {this.GetType().Name}",
                    Parent = newObj
                });
            }

            return newObj;
        }
    }
}