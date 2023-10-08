// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    /// <summary>
    /// An example of a simple in-memory Repository
    /// </summary>
    public class SaveableAggregateRootRepository : IRepository<SaveableAggregateRoot>
    {
        private readonly InMemoryRepository<SaveableAggregateRoot> _InMemoryRepository = new(BuildSaveableAggregateRootsForDemo());

        private static List<SaveableAggregateRoot> BuildSaveableAggregateRootsForDemo()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new SaveableAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                    AssociatedItems = Enumerable.Range(1, 5)
                        .Select(e => new AggregateReference<SaveableEntity>
                        {
                            Id = Guid.NewGuid(),
                            Description = "This is a dummy Aggregate",
                            TypeName = typeof(SaveableEntity).Name,
                        }).ToList()
                })
                .ToList();

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(SaveableAggregateRoot aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<SaveableAggregateRoot> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SaveableAggregateRoot> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task<IAggregateLock> LockAsync(SaveableAggregateRoot aggregateRoot)
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
        public async Task<int> SaveAsync(SaveableAggregateRoot aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UnlockAsync(SaveableAggregateRoot aggregateRoot)
        {
            await Task.CompletedTask;
        }
    }
}
