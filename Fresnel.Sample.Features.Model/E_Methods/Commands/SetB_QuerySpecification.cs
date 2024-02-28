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
    public class SetB_QuerySpecification : IQuerySpecification<ExampleBasicObject>
    {
        public async Task<IEnumerable<ExampleBasicObject>> GetResultsAsync()
        {
            return await Task.FromResult(Array.Empty<ExampleBasicObject>().AsEnumerable());
        }

        public async Task<IEnumerable<ExampleBasicObject>> GetResultsAsync(ExampleUsingCollections context)
        {
            var result =
                context.AllAvailableObjects
                .Except(context.SetA)
                .Except(context.SetB)
                .OrderBy(a => a.Name)
                .ToList();
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<IEnumerable<ExampleBasicObject>> GetResultsAsync(ExampleUsingObjects context)
        {
            var result =
                context.AllAvailableObjects
                .Except(new[] { context.SelectionA })
                .OrderBy(a => a.Name)
                .ToList();
            return await Task.FromResult(result.AsEnumerable());
        }
    }
}