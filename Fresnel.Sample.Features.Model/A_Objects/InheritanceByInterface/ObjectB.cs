// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has a Boolean
    /// </summary>
    public class ObjectB : IBaseObject
    {
        public Guid Id { get; set; }

        public bool A_BooleanValue { get; set; }
    }
}