// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.G_Factories;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has collections with other objects within them.
    /// Customisations are configured in the ModelConfig class.
    /// </summary>
    public class ExampleOfCollectionProperties
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// New items can be created within this property. Existing items cannot be added to this list.
        /// </summary>
        public ICollection<ExampleBasicObject> OwnedItems { get; set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// Existing items can be added to this property.  New items cannot be added to this list.
        /// </summary>
        [Collection(
            addMethodName: nameof(AddToAssociatedItems),
            removeMethodName: nameof(RemoveFromAssociatedItems))
        ]
        public ICollection<SaveableEntity> AssociatedItems { get; set; } = new List<SaveableEntity>();

        /// <summary>
        /// This table shows a custom set of columns in a specific order.
        /// </summary>
        public ICollection<ExampleObject> CollectionWithCustomColumns { get; set; } = new List<ExampleObject>();

        /// <summary>
        /// Adds the given entity to the AssociatedItems collection
        /// </summary>
        /// <param name="entity"></param>
        public void AddToAssociatedItems(SaveableEntity entity)
        {
            // Execute custom logic here:
            entity.Description += "This comment was added just before the item was added to the collection";

            AssociatedItems.Add(entity);
        }

        /// <summary>
        /// Removes the given entity from the AssociatedItems collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool RemoveFromAssociatedItems(SaveableEntity entity)
        {
            // Execute custom logic here:
            entity.Description += "This comment was added just before the item was removed to the collection";

            return AssociatedItems.Remove(entity);
        }

        /// <summary>
        /// Adds an item to the OwnedItems collection, 
        /// to show that collection changes are detected
        /// </summary>
        public void AddNewOwnedItem()
        {
            this.OwnedItems.Add(new ExampleBasicObject
            {
                Id = Guid.NewGuid(),
                Name = $"Test Object {Environment.TickCount}",
                Description = "This was created internally"
            });
        }
    }
}
