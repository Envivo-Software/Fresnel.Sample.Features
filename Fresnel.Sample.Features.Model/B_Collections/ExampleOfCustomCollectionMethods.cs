// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface;
using Envivo.Fresnel.Sample.Features.Model.J_Services;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object uses custom Add and Remove methods for its collections
    /// </summary>
    public class ExampleOfCustomCollectionMethods
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This collection has simple Add and Remove methods
        /// </summary>
        [Collection(addMethodName: nameof(AddToCollection1), removeMethodName: nameof(RemoveFromCollection1))]
        [Relationship(RelationshipType.Owns)]
        public ICollection<ExampleBasicObject> Collection1 { get; set; } = [];

        /// <summary>
        /// Adds the given entity to Collection1
        /// </summary>
        /// <param name="newEntity"></param>
        public void AddToCollection1(ExampleBasicObject newEntity)
        {
            // Execute custom logic here:
            newEntity.Description = $"Added by {nameof(AddToCollection1)}";
            Collection1.Add(newEntity);
        }

        /// <summary>
        /// Removes the given entity from Collection1
        /// </summary>
        /// <param name="entityToRemove"></param>
        /// <returns></returns>
        public bool RemoveFromCollection1(ExampleBasicObject entityToRemove)
        {
            // Execute custom logic here:
            return Collection1.Remove(entityToRemove);
        }

        /// <summary>
        /// This collection has Add and Remove methods that open a dialog
        /// </summary>
        [Collection(addMethodName: nameof(AddToCollection2), removeMethodName: nameof(RemoveFromCollection2))]
        [Relationship(RelationshipType.Owns)]
        public ICollection<ExampleBasicObject> Collection2 { get; set; } = [];

        /// <summary>
        /// Opens a dialog for additional information, then adds the given entity to Collection2
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="newName">The name to set on the new entity</param>
        /// <param name="newDescription">The description to set on the new entity</param>
        public void AddToCollection2(ExampleBasicObject newEntity, string newName, string newDescription)
        {
            newEntity.Name = newName;
            newEntity.Description = newDescription;

            // Execute custom logic here:
            Collection2.Add(newEntity);
        }

        /// <summary>
        /// Removes the given entity from the OwnedItems collection
        /// </summary>
        /// <param name="entityToRemove"></param>
        /// <param name="reallyRemove">Determines if the item should be removed</param>
        /// <returns></returns>
        public bool RemoveFromCollection2(ExampleBasicObject entityToRemove, bool reallyRemove)
        {
            // Execute custom logic here:
            if (reallyRemove)
            {
                return Collection2.Remove(entityToRemove);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This collection has Add and Remove methods that opens a dialog, and also uses injected dependencies
        /// </summary>
        [Collection(addMethodName: nameof(AddToCollection3), removeMethodName: nameof(RemoveFromCollection3))]
        [Relationship(RelationshipType.Owns)]
        public ICollection<ExampleBasicObject> Collection3 { get; set; } = [];

        /// <summary>
        /// Opens a dialog for additional information, then adds the given entity to Collection2
        /// </summary>
        /// <param name="dateTimeValueProvider">An injected Domain dependency</param>
        /// <param name="newEntity"></param>
        /// <param name="newName">The name to set on the new entity</param>
        public void AddToCollection3(DateTimeValueProvider dateTimeValueProvider, ExampleBasicObject newEntity, string newName)
        {
            newEntity.Name = newName;
            newEntity.Description = $"Created at {dateTimeValueProvider.GetValue(this)}";

            // Execute custom logic here:
            Collection3.Add(newEntity);
        }

        /// <summary>
        /// Removes the given entity from the OwnedItems collection
        /// </summary>
        /// <param name="dateTimeValueProvider">An injected Domain dependency</param>
        /// <param name="entityToRemove"></param>
        /// <param name="reallyRemove">Determines if the item should be removed</param>
        /// <returns></returns>
        public bool RemoveFromCollection3(DateTimeValueProvider dateTimeValueProvider, ExampleBasicObject entityToRemove, bool reallyRemove)
        {
            // We're not doing anything with the dependency, but we're showing that it's injected

            // Execute custom logic here:
            if (reallyRemove)
            {
                return Collection3.Remove(entityToRemove);
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// This collection uses Interfaces
        /// </summary>
        [Collection(addMethodName: nameof(AddToCollection4), removeMethodName: nameof(RemoveFromCollection4))]
        [Relationship(RelationshipType.Owns)]
        public ICollection<IBaseObject> Collection4 { get; set; } = [];

        /// <summary>
        /// Opens a dialog for additional information, then adds the given entity to Collection2
        /// </summary>
        /// <param name="newEntity"></param>
        public void AddToCollection4(IBaseObject newEntity)
        {
            // Execute custom logic here:
            newEntity.CommonValue = $"This was modified by {nameof(AddToCollection4)}";

            Collection4.Add(newEntity);
        }

        /// <summary>
        /// Removes the given entity from the OwnedItems collection
        /// </summary>
        /// <param name="entityToRemove"></param>
        /// <returns></returns>
        public bool RemoveFromCollection4(IBaseObject entityToRemove)
        {
            return Collection4.Remove(entityToRemove);
        }
    }
}
