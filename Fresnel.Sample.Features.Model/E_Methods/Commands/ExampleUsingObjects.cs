// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods.Commands
{
    /// <summary>
    /// An example of a Command object, that uses Properties to represent 'parameters'.
    /// This also shows how properties are updated if the context changes.
    /// </summary>
    public class ExampleUsingObjects : ICommandObject, IValueObject
    {
        public Guid Id { get; set; }

        public ExampleUsingObjects()
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
        [FilterQuerySpecification(typeof(SetA_QuerySpecification))]
        [UI(UiRenderOption.InlineSimple, preferredControl: UiControlType.Select)]
        [AllowedOperations(canAdd: false, canModify: true)]
        public ExampleBasicObject SelectionA { get; set; }

        /// <summary>
        /// Items selected from this set are not available in Set A
        /// </summary>
        [FilterQuerySpecification(typeof(SetB_QuerySpecification))]
        [UI(UiRenderOption.InlineSimple, preferredControl: UiControlType.Select)]
        [AllowedOperations(canAdd: false, canModify: true)]
        public ExampleBasicObject SelectionB { get; set; }

        /// <summary>
        /// Executes the command when SelectionA and SelectionB have values
        /// </summary>
        public bool IsReadyToExecute => (SelectionA != null && SelectionB != null);

        public object Execute()
        {
            // Do something with the 'parameters'
            return null;
        }
    }
}