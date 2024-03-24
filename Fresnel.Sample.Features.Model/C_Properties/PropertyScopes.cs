// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    public class PropertyScopes
    {
        public Guid Id { get; set; }

        public string? PublicGetterAndPublicSetter { get; set; }

        public string? PublicGetterAndInternalSetter { get; internal set; }

        public string? PublicGetterAndPrivateSetter { get; private set; }

        internal string InternalGetterAndInternalSetter { get; set; }

        public string? PrivateGetterAndPublicSetter { private get; set; }

        private string PrivateGetterAndPrivateSetter { get; set; }
    }
}