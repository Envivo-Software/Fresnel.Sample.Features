// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has collections with other objects within them
    /// </summary>
    public class ObjectWithCollections
    {
        private IList<BasicObject> _OwnedItems = new List<BasicObject>();
        private IList<SaveableEntity> _AssociatedItems = new List<SaveableEntity>();

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
        /// New items can be created within this property. Existing items cannot be added to this list.
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public IList<BasicObject> OwnedItems
        {
            get { return _OwnedItems; }
            set { _OwnedItems = value; }
        }

        /// <summary>
        /// Existing items can be added to this property.  New items cannot be added to this list.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public IList<SaveableEntity> AssociatedItems
        {
            get { return _AssociatedItems; }
            set { _AssociatedItems = value; }
        }

        ///// <summary>
        ///// Adds the given entity to the AssociatedItems collection
        ///// </summary>
        ///// <param name="entity"></param>
        //public void AddToAssociatedItems(SaveableEntity entity)
        //{
        //    // Execute custom logic here
        //    _AssociatedItems.Add(entity);
        //}

        ///// <summary>
        ///// Removes the given entity from the AssociatedItems collection
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public bool RemoveFromAssociatedItems(SaveableEntity entity)
        //{
        //    // Execute custom logic here
        //    return _AssociatedItems.Remove(entity);
        //}

        /// <summary>
        /// Adds an item to the OwnedItems collection, 
        /// to show that collection changes are detected
        /// </summary>
        public void AddNewOwnedItem()
        {
            this.OwnedItems.Add(new BasicObject
            {
                Id = Guid.NewGuid(),
                Name = $"Test Object {Environment.TickCount}",
                Description = "This was created internally"
            });
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