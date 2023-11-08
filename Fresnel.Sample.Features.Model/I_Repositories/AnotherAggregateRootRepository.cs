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
    public class AnotherAggregateRootRepository : IRepository<AnotherAggregateRoot>
    {
        private InMemoryRepository<AnotherAggregateRoot> _InMemoryRepository;

        public AnotherAggregateRootRepository(SaveableEntityRepository saveableEntityRepository)
        {
            _InMemoryRepository = new(BuildAggregateRootsForDemo(saveableEntityRepository));
        }

        private List<AnotherAggregateRoot> BuildAggregateRootsForDemo(SaveableEntityRepository saveableEntityRepository)
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new AnotherAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(AnotherAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                })
                .ToList();

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(AnotherAggregateRoot aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<AnotherAggregateRoot> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AnotherAggregateRoot> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task<IAggregateLock> LockAsync(AnotherAggregateRoot aggregateRoot)
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
        public async Task<int> SaveAsync(AnotherAggregateRoot aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UnlockAsync(AnotherAggregateRoot aggregateRoot)
        {
            await Task.CompletedTask;
        }
    }
}
