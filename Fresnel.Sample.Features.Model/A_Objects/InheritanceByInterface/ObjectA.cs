// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This object has an Integer
    /// </summary>
    public class ObjectA : IBaseObject
    {
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public long Version { get; set; }

        public int AnIntegerValue { get; set; }

        public string CommonValue { get; set; }
    }
}
