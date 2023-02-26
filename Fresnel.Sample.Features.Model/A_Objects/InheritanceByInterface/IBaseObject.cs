// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This type will appear in the UI, but cannot be created
    /// </summary>
    public interface IBaseObject
    {
        public Guid Id { get; set; }
    }
}