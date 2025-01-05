// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object uses custom add and remove methods, which aren't fully implemented
    /// </summary>
    public class ExampleOfIncorrectCollectionMethods
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// New items can be created within this property. Existing items cannot be added to this list.
        /// </summary>
        [Collection(addMethodName: nameof(AddToItems), removeMethodName: nameof(RemoveFromItems))]
        [Relationship(RelationshipType.Owns)]
        public IList<ExampleBasicObject> OwnedItems { get; set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// Adds the given entity to the OwnedItems collection
        /// </summary>
        /// <param name="entity"></param>
        public void AddToItems(ExampleBasicObject entity)
        {
            // Execute custom logic here:
            entity.Description += "This comment was added just before the item was added to the collection";

            // This will cause an error at run-time:
            //OwnedItems.Add(entity);
        }

        /// <summary>
        /// Removes the given entity from the OwnedItems collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool RemoveFromItems(ExampleBasicObject entity)
        {
            // Execute custom logic here:
            entity.Description += "This comment was added just before the item was removed to the collection";

            // This will cause an error at run-time:
            //return OwnedItems.Remove(entity);

            return true;
        }
    }
}