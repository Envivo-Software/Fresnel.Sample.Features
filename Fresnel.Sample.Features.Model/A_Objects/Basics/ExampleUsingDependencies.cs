// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object has dependencies automatically injected into it
    /// </summary>
    public class ExampleUsingDependencies
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="basicObjectFactory"></param>
        public ExampleUsingDependencies(IFactory<ExampleBasicObject> basicObjectFactory)
        {
            BasicObject = basicObjectFactory.Create();
            Name = "This name is provided by default";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="basicObjectFactory"></param>
        /// <param name="name"></param>
        public ExampleUsingDependencies(IFactory<ExampleBasicObject> basicObjectFactory, string name)
        {
            BasicObject = basicObjectFactory.Create();
            Name = name;
        }

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This property will have an item created by the injected factory
        /// </summary>
        public ExampleBasicObject BasicObject { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}