// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods.Commands
{
    public class SetA_QuerySpecification : IQuerySpecification<BasicObject>
    {
        public async Task<IEnumerable<BasicObject>> GetResultsAsync()
        {
            return await Task.FromResult(Array.Empty<BasicObject>().AsEnumerable());
        }

        public async Task<IEnumerable<BasicObject>> GetResultsAsync(CommandSampleWithCollections context)
        {
            var result =
                context.AllAvailableObjects
                .Except(context.SetA)
                .Except(context.SetB)
                .OrderBy(a => a.Name)
                .ToList();
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<IEnumerable<BasicObject>> GetResultsAsync(CommandSampleWithObjects context)
        {
            var result =
                context.AllAvailableObjects
                .Except(new[] { context.SelectionB })
                .OrderBy(a => a.Name)
                .ToList();
            return await Task.FromResult(result.AsEnumerable());
        }
    }
}