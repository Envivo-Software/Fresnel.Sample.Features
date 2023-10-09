// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has collections whose contents can be updated from a hidden list
    /// </summary>
    public class ObjectWithCollectionOperations
    {
        private List<BasicObject> _PreCannedList = new();

        public ObjectWithCollectionOperations()
        {
            for (var i = 1; i <= 10; i++)
            {
                _PreCannedList.Add(new BasicObject
                {
                    Id = Guid.NewGuid(),
                    Name = $"This is pre-canned item {i}",
                    Description = "This is from an internal list that is hidden from the UI"
                });
            }
        }

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        [UI(UiRenderOption.InlineExpanded)]
        [AllowedOperations(canCreate: false, canAdd: false, canRemove: false)]
        public ICollection<BasicObject> OwnedItems { get; set; } = new List<BasicObject>();

        /// <summary>
        /// Returns all of the items in the internal list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BasicObject> GetAllItems() => _PreCannedList;

        /// <summary>
        /// Adds an item to the OwnedItems collection, 
        /// to show that collection changes are detected
        /// </summary>
        [Method(relatedPropertyName: nameof(OwnedItems))]
        public void MoveItemFromInternalListToOwnedItems()
        {
            if (_PreCannedList.Count == 0)
                return;

            var item = _PreCannedList[0];
            _PreCannedList.Remove(item);
            this.OwnedItems.Add(item);
        }

        /// <summary>
        /// Removes an item from the OwnedItems collection, 
        /// to show that collection changes are detected
        /// </summary>
        [Method(relatedPropertyName: nameof(OwnedItems))]
        public void RemoveItemFromOwnedItemsBackToInternalList()
        {
            if (OwnedItems.Count == 0)
                return;

            var item = OwnedItems.First();
            _PreCannedList.Add(item);
            this.OwnedItems.Remove(item);
        }

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