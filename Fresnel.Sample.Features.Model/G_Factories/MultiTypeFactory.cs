// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.C_Properties;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.G_Factories
{
    public class MultiTypeFactory : IFactory<MultiType>
    {
        /// <summary>
        /// Creates a single MultiType object
        /// </summary>
        /// <returns></returns>
        public MultiType Create()
        {
            return Create(5);
        }

        /// <summary>
        /// Creates a single MultiType object, but with 'n' items in it's collection
        /// </summary>
        /// <param name="itemCount">The number of items to add to the collection</param>
        /// <returns></returns>
        public MultiType Create(int itemCount)
        {
            var newObj = new MultiType
            {
                Id = Guid.NewGuid(),
                A_DateTime = DateTime.Now,
                A_String = $"Created by {this.GetType().Name}"
            };

            for (var i = 0; i < itemCount; i++)
            {
                newObj.A_Collection.Add(new MultiTypeChild
                {
                    Id = Guid.NewGuid(),
                    Name = $"Item no {i}",
                    Description = $"Created by {this.GetType().Name}"
                });
            }

            return newObj;
        }
    }
}