// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.J_Services
{
    /// <summary>
    /// This Domain Services provide access to logic without instantiating an object
    /// </summary>
    public class ObjectWithInjectedDependencies : IEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// This service is injected, and will not appear in the UI
        /// </summary>
        public DomainService DomainService { get; set; }

        /// <summary>
        /// Invokes a method using the DomainService
        /// </summary>
        /// <returns></returns>
        public string InvokeService()
        {
            return DomainService?.DownloadFile();
        }
    }
}