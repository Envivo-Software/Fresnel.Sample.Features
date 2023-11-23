// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of properties that are not supported in the UI
    /// </summary>
    public class UnsupportedPropertyTypes
    {
        public Guid Id { get; set; }

        public Guid Guid { get; set; }

        public IEnumerable<string> StringEnumerable { get; set; }

        public string[] StringArray { get; set; }

        public IEnumerable<int> IntEnumerable { get; set; }

        public int[] IntArray { get; set; }

        public Dictionary<int,string> DictionaryOfStrings { get; set; }

    }
}