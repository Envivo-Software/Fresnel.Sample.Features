// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// Examples of collections with different behaviours
    /// </summary>
    public class ExampleOfExplicitOperations
    {
        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This collection allows adding new items, linking existing items, and removing items
        /// </summary>
        [Relationship(RelationshipType.Unspecified)]
        [AllowedOperations(canCreate: true, canAdd: true, canRemove: true)]
        public ICollection<ExampleBasicObject> AllOperationsAllowed { get; internal set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// This collection allows adding new items, associating existing items, but not removing items
        /// </summary>
        [Relationship(RelationshipType.Unspecified)]
        [AllowedOperations(canCreate: true, canAdd: true, canRemove: false)]
        public ICollection<ExampleBasicObject> AddNewAndAssociate { get; internal set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// This collection allows adding new items, but not associating existing items, and not removing items
        /// </summary>
        [Relationship(RelationshipType.Unspecified)]
        [AllowedOperations(canCreate: true, canAdd: false, canRemove: false)]
        public ICollection<ExampleBasicObject> AddNewOnly { get; internal set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// This collection allows associating existing items, but not adding new items, and not removing items
        /// </summary>
        [Relationship(RelationshipType.Unspecified)]
        [AllowedOperations(canCreate: false, canAdd: true, canRemove: false)]
        public ICollection<ExampleBasicObject> AssociateExistingOnly { get; internal set; } = new List<ExampleBasicObject>();

        /// <summary>
        /// This collection does not allow any creating, associating, or removing
        /// </summary>
        [Relationship(RelationshipType.Unspecified)]
        [AllowedOperations(canCreate: false, canAdd: false, canRemove: false)]
        public ICollection<ExampleBasicObject> NoOperationsAllowed { get; internal set; } = new List<ExampleBasicObject>();
    }
}