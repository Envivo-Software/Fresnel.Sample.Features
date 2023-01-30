// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.D_Enums;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    /// <summary>
    /// A set of methods
    /// </summary>
    public class MethodSamples
    {
        private IFactory<BasicObject> _BasicObjectFactory;

        public MethodSamples(IFactory<BasicObject> basicObjectFactory)
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
        /// All parameters are supplied with default values.
        /// The result will appear in the Message Panel.
        /// </summary>
        /// <param name="enumFilter">This will be automatically injected</param>
        /// <param name="aString">This will accept a String</param>
        /// <param name="aNumber">This will accept an Integer</param>
        /// <param name="aDate">This will accept a Date</param>
        public string MethodWithValueParameters
        (
            IQuerySpecification<EnumValues.IndividualOptions> enumFilter,
            string aString,
            int aNumber,
            DateTime aDate
        )
        {
            if (enumFilter == null)
            {
                throw new ArgumentNullException("enumFilter");
            }

            return $"{nameof(MethodWithValueParameters)} executed with the values [{aString}, {aNumber}, {aDate}]";
        }

        /// <summary>
        /// This method accepts objects as parameters, and will open a dialog.
        /// The method can only be invoked when the user supplies the parameter values.
        /// The result will appear in the Message Panel.
        /// </summary>
        /// <param name="entity">This will allow ONE entity to be chosen</param>
        /// <param name="entities">This will allow multiple entities to be chosen</param>
        /// <returns></returns>
        public string MethodWithObjectParameters
        (
            [Required]
            [UI(preferredControl: UiControlType.Select)]
            [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
            SaveableEntity entity,

            [Required]
            [FilterQuerySpecification(typeof(SaveableEntityQuerySpecification))]
            IEnumerable<SaveableEntity> entities
        )
        {
            return $"{nameof(MethodWithObjectParameters)} executed with the selection '{entity?.Name}'";
        }

        /// <summary>
        /// This method has nullable parameters, and will open a dialog.
        /// </summary>
        /// <returns></returns>
        public string MethodWithNullableParameters
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
        /// The parameters are configured in <see cref="ModelConfig.Configure_E_Methods"/>
        /// </summary>
        /// <returns></returns>
        public string MethodWithRequiredParameters
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
        public string MethodThatReturnsA_String()
        {
            return "This is a string";
        }

        /// <summary>
        /// This method returns an Object.
        /// It will invoke without showing a dialog, and the result will appear in the Message Panel.
        /// </summary>
        /// <returns></returns>
        public BasicObject MethodThatReturnsAnObject()
        {
            var result = _BasicObjectFactory.Create();
            return result;
        }

        /// <summary>
        /// This method takes 10 seconds to run.
        /// </summary>
        /// <returns></returns>
        public string LongRunningSyncMethod()
        {
            var runFor = TimeSpan.FromSeconds(10);
            var runUntil = DateTime.Now.Add(runFor);

            while (DateTime.Now < runUntil)
            {
                System.Threading.Thread.Sleep(1000);
                Trace.TraceInformation("Running...");
            }

            return nameof(LongRunningSyncMethod);
        }

        public void MethodWithoutDescription()
        {
        }
    }
}