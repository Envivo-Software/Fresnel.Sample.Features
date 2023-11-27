using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    public class MethodConfirmationSamplesRepository : IRepository<MethodConfirmationSamples>
    {
        private readonly InMemoryRepository<MethodConfirmationSamples> _InMemoryRepository = new();

        public async Task DeleteAsync(MethodConfirmationSamples aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        public IQueryable<MethodConfirmationSamples> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        public async Task<MethodConfirmationSamples> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        public async Task<IAggregateLock> LockAsync(MethodConfirmationSamples aggregateRoot)
        {
            return await _InMemoryRepository.LockAsync(aggregateRoot);
        }

        public async Task<int> SaveAsync(MethodConfirmationSamples aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        public async Task UnlockAsync(MethodConfirmationSamples aggregateRoot)
        {
            await _InMemoryRepository.UnlockAsync(aggregateRoot);
        }
    }
}
