// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has a DateTime
    /// </summary>
    public class ObjectD : IBaseObject
    {
        public Guid Id { get; set; }

        public DateTime A_DateTime { get; set; }
    }
}