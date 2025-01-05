// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods.Commands
{
    /// <summary>
    /// An example of a Command object, that uses Properties to represent 'parameters'.
    /// This also shows how properties are updated if the other content changes.
    /// </summary>
    public class ExampleUsingObjects :
        ICommandObject,
        ICommandObject<ExamplesOfMethods>,
        IValueObject
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
        /// Enable the command when SelectionA and SelectionB have values
        /// </summary>
        public bool IsReadyToExecute => (SelectionA != null && SelectionB != null);

        /// <summary>
        /// Executes the command when items are chosen for SelectionA and SelectionB
        /// </summary>
        /// <returns></returns>
        public void Execute()
        {
            // Do something with the SelectionA and SelectionB 'parameters'
            Trace.TraceInformation($"Executed with '{SelectionA}' and {SelectionB}");
        }

        /// <summary>
        /// Executes the command when items are chosen for SelectionA and SelectionB, and within the context of a parent object
        /// </summary>
        /// <returns></returns>
        public void Execute(ExamplesOfMethods context)
        {
            // We can also do something with the object that triggered this method:
            Trace.TraceInformation($"Executed within the context of '{context}', with '{SelectionA}' and {SelectionB}");
        }
    }
}