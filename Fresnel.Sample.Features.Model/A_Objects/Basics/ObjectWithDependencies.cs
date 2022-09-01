// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This object has dependencies automatically injected into it
    /// </summary>
    public class ObjectWithDependencies
    {
        public ObjectWithDependencies(IFactory<BasicObject> basicObjectFactory)
        {
            BasicObject = basicObjectFactory.Create();
            Name = "This name is provided by default";
        }

        public ObjectWithDependencies(IFactory<BasicObject> basicObjectFactory, string name)
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
        public BasicObject BasicObject { get; private set; }

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