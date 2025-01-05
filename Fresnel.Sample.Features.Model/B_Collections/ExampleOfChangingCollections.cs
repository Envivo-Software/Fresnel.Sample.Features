// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has a collection whose contents completely change
    /// </summary>
    public class ExampleOfChangingCollections
    {
        private ICollection<ExampleBasicObject> _PreDefinedItems;

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This collection's contents change every time the button is clicked
        /// </summary>
        public List<ExampleBasicObject> Items { get; internal set; } = new List<ExampleBasicObject>();

        public int ItemsPerPage { get; set; } = 10;

        /// <summary>
        /// Changes the associated Collection's contents
        /// </summary>
        public void ChangeContents()
        {
            _PreDefinedItems ??= CreatePreDefinedItems();

            var replacementSet =
                _PreDefinedItems
                .OrderBy(i => Guid.NewGuid())
                .Take(ItemsPerPage)
                .ToList();
            Items.Clear();
            Items.AddRange(replacementSet);
        }

        private ICollection<ExampleBasicObject> CreatePreDefinedItems()
        {
            return
                Enumerable.Range(1, ItemsPerPage * 4)
                .Select(i => new ExampleBasicObject
                {
                    Id = Guid.NewGuid(),
                    Name = $"Item No{i}",
                    Description = $"This is the description for item number {i}"
                })
                .ToList();
        }

    }
}