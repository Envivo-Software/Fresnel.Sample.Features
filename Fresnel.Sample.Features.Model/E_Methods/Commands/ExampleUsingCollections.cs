// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods.Commands
{
    /// <summary>
    /// An example of a Command object, that uses Properties to represent 'parameters'.
    /// This also shows how properties are updated if the context changes.
    /// </summary>
    public class ExampleUsingCollections : ICommandObject, IValueObject
    {
        public Guid Id { get; set; }

        public ExampleUsingCollections()
        {
            for (var i = 1; i <= 10; i++)
            {
                AllAvailableObjects.Add(new ExampleBasicObject
                {
                    Id = Guid.NewGuid(),
                    Name = $"Item {i:00}"
                });
            }
        }

        [AllowedOperations(canAdd: false, canRemove: false, canClear: false)]
        public ICollection<ExampleBasicObject> AllAvailableObjects { get; } = new List<ExampleBasicObject>();

        /// <summary>
        /// Items selected from this set are not available in Set B
        /// </summary>
        [UI(UiRenderOption.InlineExpanded)]
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SetA_QuerySpecification))]
        public ICollection<ExampleBasicObject> SetA { get; } = new List<ExampleBasicObject>();

        /// <summary>
        /// Items selected from this set are not available in Set A
        /// </summary>
        [UI(UiRenderOption.InlineExpanded)]
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(SetB_QuerySpecification))]
        public ICollection<ExampleBasicObject> SetB { get; } = new List<ExampleBasicObject>();

        public bool IsReadyToExecute => (SetA.Any() || SetB.Any());

        /// <summary>
        /// Executes the command when items are added to SetA and SetB
        /// </summary>
        /// <returns></returns>
        public object Execute()
        {
            // Do something with the SetA and SetB 'parameters'
            return null;
        }
    }
}