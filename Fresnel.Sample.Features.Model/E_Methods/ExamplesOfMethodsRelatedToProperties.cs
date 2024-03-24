// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    /// <summary>
    /// A set of properties with methods associated with each one
    /// </summary>
    public class ExamplesOfMethodsRelatedToProperties
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A read-only string property
        /// </summary>
        public string? A_String { get; private set; }

        /// <summary>
        /// Used to set the string
        /// </summary>
        /// <param name="newValue"></param>
        [Method(RelatedPropertyName = nameof(A_String))]
        public void Set_A_String(string newValue)
        {
            A_String = newValue;
        }

        /// <summary>
        /// A read-only object property
        /// </summary>
        public ExampleBasicObject An_Object { get; private set; } = new ExampleBasicObject();

        /// <summary>
        /// Used to change the object's name
        /// </summary>
        /// <param name="newName"></param>
        [Method(RelatedPropertyName = nameof(An_Object))]
        public void Set_BasicObject_Name(string newName)
        {
            An_Object.Name = newName;
        }

        /// <summary>
        /// A collection of objects
        /// </summary>
        public ICollection<ExampleBasicObject> An_Object_Collection { get; private set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// Used to add a new item to the collection
        /// </summary>
        /// <returns></returns>
        [Method(RelatedPropertyName = nameof(An_Object_Collection))]
        public ExampleBasicObject AddAnotherItemToCollection()
        {
            var newItem = new ExampleBasicObject();
            An_Object_Collection.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// This method is visible on every tab within the card
        /// </summary>
        public void CommonMethod()
        {

        }
    }
}