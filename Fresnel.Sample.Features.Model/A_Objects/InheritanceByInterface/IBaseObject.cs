// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByInterface
{
    /// <summary>
    /// This type will appear in the UI, but cannot be created
    /// </summary>
    public interface IBaseObject : IEntity, IPersistable
    {

    }
}