// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has a constructor argument
    /// </summary>
    public class NestedChildObject
    {
        public NestedChildObject(ExampleOfCollectionProperties parentObject)
        {
            ParentObject = parentObject;
        }

        /// <summary>
        /// The [Key] attribute
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The owner of this object
        /// </summary>
        public ExampleOfCollectionProperties ParentObject { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}