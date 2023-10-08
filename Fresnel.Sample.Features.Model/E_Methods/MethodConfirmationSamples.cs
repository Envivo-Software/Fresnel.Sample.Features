// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    /// <summary>
    /// A set of methods demonstrating custom confirmation dialogs
    /// </summary>
    public class MethodConfirmationSamples : IAggregateRoot
    {
        private IFactory<BasicObject> _BasicObjectFactory;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="basicObjectFactory"></param>
        public MethodConfirmationSamples(IFactory<BasicObject> basicObjectFactory)
        {
            _BasicObjectFactory = basicObjectFactory;
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// This method returns an Object.
        /// It will show as custom a dialog to confirm the operation.
        /// </summary>
        /// <returns></returns>
        [Method(mandatoryPromptText: "This custom text should appear as a prompt")]
        public BasicObject MethodWithConfirmationPrompt()
        {
            var result = _BasicObjectFactory.Create();
            return result;
        }

        /// <summary>
        /// This method will show as custom a dialog if the object has unsaved changes.
        /// It will only return a result after the object is saved.
        /// </summary>
        /// <returns></returns>
        [Method(unsavedChangesPromptText: "This method cannot run until changes have been saved")]
        public BasicObject MethodWithUnsavedChangesPrompt()
        {
            var result = _BasicObjectFactory.Create();
            return result;
        }
    }
}