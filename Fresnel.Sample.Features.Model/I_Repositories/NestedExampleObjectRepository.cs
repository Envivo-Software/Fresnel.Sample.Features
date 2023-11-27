// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
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
    public class NestedExampleObjectRepository : IRepository<NestedExampleObject>, IPagedFiltering<NestedExampleObject>
    {
        private readonly InMemoryRepository<NestedExampleObject> _InMemoryRepository = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(NestedExampleObject aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<NestedExampleObject> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async Task<(IEnumerable<NestedExampleObject>, int)> GetResultsPageAsync(IQueryFilter queryFilter)
        {
            // TODO: Use Dynamic Linq to parse the IQueryFilter, and apply it to the collection
            dynamic result = (GetQuery().AsEnumerable(), GetQuery().Count());
            return await Task.FromResult(result);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<NestedExampleObject> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task<IAggregateLock> LockAsync(NestedExampleObject aggregateRoot)
        {
            return await _InMemoryRepository.LockAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public async Task<int> SaveAsync(NestedExampleObject aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UnlockAsync(NestedExampleObject aggregateRoot)
        {
            await Task.CompletedTask;
        }
    }
}
