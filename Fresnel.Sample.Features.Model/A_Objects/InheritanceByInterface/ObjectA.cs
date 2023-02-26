// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has an Integer
    /// </summary>
    public class ObjectA : IBaseObject
    {
        public Guid Id { get; set; }

        public int AnIntegerValue { get; set; }
    }
}