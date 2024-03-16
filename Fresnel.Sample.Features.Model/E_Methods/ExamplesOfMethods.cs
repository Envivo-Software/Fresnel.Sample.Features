// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using Envivo.Fresnel.Sample.Features.Model.E_Methods.Commands;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    /// <summary>
    /// A set of methods
    /// </summary>
    public class ExamplesOfMethods
    {
        private IFactory<ExampleBasicObject> _BasicObjectFactory;

        /// <inheritdoc/>
        /// <param name="basicObjectFactory"></param>
        public ExamplesOfMethods(IFactory<ExampleBasicObject> basicObjectFactory)
        {
            _BasicObjectFactory = basicObjectFactory;
        }

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This method returns no value.
        /// It will invoke without showing a dialog.
        /// </summary>
        public void MethodWithNoReturnValue()
        {
            Trace.TraceInformation(nameof(MethodWithNoReturnValue));
        }

        /// <summary>
        /// This method accepts a single parameter, and will open a dialog.
        /// The method can only be invoked when the user supplies the parameter value.
        /// </summary>
        /// <param name="dateTime"></param>
        public void MethodWithOneParameter
        (
            [DataType(DataType.Date)]
            DateTime dateTime
        )
        {
            Trace.TraceInformation(nameof(MethodWithOneParameter));
        }

        /// <summary>
        /// This method accepts multiple parameters, and will open a dialog.
        /// All parameters are supplied with their natural default values.
        /// The result will appear in the Message Panel.
        /// </summary>
        /// <param name="enumFilter">This will be automatically injected</param>
        /// <param name="aBoolean">This will accept a Boolean</param>
        /// <param name="aString">This will accept a String</param>
        /// <param name="aNumber">This will accept an Integer</param>
        /// <param name="aDate">This will accept a Date</param>
        public string? MethodWithValueParameters
        (
            IQuerySpecification<EnumValues.IndividualOptions> enumFilter,
            bool aBoolean,
            string aString,
            int aNumber,
            DateTime aDate
        )
        {
            if (enumFilter == null)
            {
                throw new ArgumentNullException("enumFilter");
            }

            return $"{nameof(MethodWithValueParameters)} executed with the values [{aBoolean}, {aString}, {aNumber}, {aDate}]";
        }

        /// <summary>
        /// This method has optional parameters with custom default values, and will open a dialog.
        /// The result will appear in the Message Panel.
        /// </summary>
        /// <param name="aString">This will accept a String</param>
        /// <param name="aNumber">This will accept an Integer</param>
        public string? MethodWithOptionalParameters
        (
            string aString = "A preset string",
            int aNumber = 12345
        )
        {
            return $"{nameof(MethodWithOptionalParameters)} executed with the values [{aString}, {aNumber}]";
        }

        /// <summary>
        /// This method accepts one object as a parameter.
        /// It will open a search dialog, and the method is invoked when the selection is made
        /// </summary>
        /// <param name="entity">This will allow ONE entity to be chosen</param>
        /// <returns></returns>
        public string? MethodWithSingleObjectParameter
        (
            SaveableEntity entity
        )
        {
            return $"{nameof(MethodWithSingleObjectParameter)} executed with the selection '{entity?.Name}'";
        }

        /// <summary>
        /// This method accepts objects as parameters, and will open a dialog.
        /// The method can only be invoked when the user supplies the parameter values.
        /// The result will appear in the Message Panel.
        /// </summary>
        /// <param name="entity2">This will allow ONE entity to be chosen from a modal</param>
        /// <param name="entity">This will allow ONE entity to be chosen from a drop-down</param>
        /// <param name="entities">This will allow multiple entities to be chosen</param>
        /// <returns></returns>
        public string? MethodWithObjectParameters
        (
            [Required]
            [UI(preferredControl: UiControlType.Select)]
            [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
            SaveableEntity entity,

            [Required]
            [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
            SaveableEntity entity2,

            [Required]
            [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
            IEnumerable<SaveableEntity> entities
        )
        {
            return $"{nameof(MethodWithObjectParameters)} executed with the selection '{entity?.Name}' and {entity2?.Name}";
        }

        /// <summary>
        /// This method has nullable parameters, and will open a dialog.
        /// </summary>
        /// <returns></returns>
        public string? MethodWithNullableParameters
        (
            string aString,
            int? anInteger,
            bool? aBoolean,
            [DataType(DataType.Date)]
            DateTime? aDate
        )
        {
            return $"{nameof(MethodWithNullableParameters)} executed with the values [{aString}, {anInteger}, {aBoolean}, {aDate}]";
        }

        /// <summary>
        /// This method has nullable parameters all that are all 'Required', and will open a dialog.
        /// The parameters are configured in ModelConfig.Configure_E_Methods
        /// </summary>
        /// <returns></returns>
        public string? MethodWithRequiredParameters
        (
            string aString,
            int? anInteger,
            bool? aBoolean,
            DateTime? aDate
        )
        {
            return $"{nameof(MethodWithRequiredParameters)} executed with the values [{aString}, {anInteger}, {aBoolean}, {aDate}]";
        }

        /// <summary>
        /// This method simply returns a string.
        /// It will invoke without showing a dialog, and the result will appear in the Message Panel.
        /// </summary>
        /// <returns></returns>
        public string? MethodThatReturnsA_String()
        {
            return "This is a string";
        }

        /// <summary>
        /// This method returns an Object.
        /// It will invoke without showing a dialog, and the result will appear in the Message Panel.
        /// </summary>
        /// <returns></returns>
        public ExampleBasicObject MethodThatReturnsAnObject()
        {
            var result = _BasicObjectFactory.Create();
            return result;
        }

        /// <summary>
        /// This method takes 5 seconds to run.
        /// </summary>
        /// <returns></returns>
        public async Task<string> LongRunningMethod()
        {
            var runFor = TimeSpan.FromSeconds(10);
            var runUntil = DateTime.Now.Add(runFor);

            Trace.TraceInformation("Running...");
            await Task.Delay(5000);

            return nameof(LongRunningMethod);
        }

        /// <summary>
        /// This async method returns a value
        /// </summary>
        /// <returns></returns>
        public async Task<string> AsyncMethodWithReturnValue()
        {
            return await Task.FromResult(nameof(AsyncMethodWithReturnValue));
        }

        /// <summary>
        /// This async method doesn't return any value
        /// </summary>
        /// <returns></returns>
        public async Task AsyncMethodWithoutReturnValue()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// This method returns an ICommandObject, which presents itself as a dialog
        /// </summary>
        /// <returns></returns>
        public ExampleUsingObjects MethodUsingCommandObject()
        {
            return new();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void MethodWithoutDescription()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }
    }
}