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

        public Task DeleteAsync(MethodConfirmationSamples aggregateRoot)
        {
            return _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        public IQueryable<MethodConfirmationSamples> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        public Task<MethodConfirmationSamples> LoadAsync(Guid id)
        {
            return _InMemoryRepository.LoadAsync(id);
        }

        public Task<IAggregateLock> LockAsync(MethodConfirmationSamples aggregateRoot)
        {
            return _InMemoryRepository.LockAsync(aggregateRoot);
        }

        public Task<int> SaveAsync(MethodConfirmationSamples aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        public Task UnlockAsync(MethodConfirmationSamples aggregateRoot)
        {
            return _InMemoryRepository.UnlockAsync(aggregateRoot);
        }
    }
}
