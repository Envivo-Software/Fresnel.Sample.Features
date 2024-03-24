// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.NestedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    /// <summary>
    /// An example of a simple in-memory Repository that uses custom filtering
    /// </summary>
    public class ExampleOfNestedObjectsRepository : IRepository<ExampleOfNestedObjects>, IPagedFiltering<ExampleOfNestedObjects>
    {
        private readonly InMemoryRepository<ExampleOfNestedObjects> _InMemoryRepository = new();

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(ExampleOfNestedObjects aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <inheritdoc/>
        public IQueryable<ExampleOfNestedObjects> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<ExampleOfNestedObjects>, int)> GetResultsPageAsync(IQueryFilter queryFilter)
        {
            // TODO: Use Dynamic Linq to parse the IQueryFilter, and apply it to the collection
            dynamic result = (GetQuery().AsEnumerable(), GetQuery().Count());
            return await Task.FromResult(result);
        }

        /// <inheritdoc/>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExampleOfNestedObjects> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public async Task<int> SaveAsync(ExampleOfNestedObjects aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }
    }
}
