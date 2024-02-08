using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model
{
    public class DemoInitialiser : IDomainDependency
    {
        private readonly SaveableAggregateRootRepository _SaveableAggregateRootRepository;
        private readonly DemoSaveableAggregateRootsBuilder _DemoSaveableAggregateRootsBuilder;
        private readonly SaveableEntityRepository _SaveableEntityRepository;
        private readonly ObjectWithEagerLoadedPropertiesRepository _ObjectWithEagerLoadedPropertiesRepository;
        private readonly ObjectWithEagerLoadedPropertiesBuilder _DemoObjectWithEagerLoadedPropertiesBuilder;
        private readonly DemoSaveableEntitiesBuilder _DemoSaveableEntitiesBuilder;
        private readonly AnotherAggregateRootRepository _AnotherAggregateRootRepository;
        private readonly DemoAnotherAggregateRootsBuilder _DemoAnotherAggregateRootsBuilder;
        private readonly NestedExampleObjectRepository _NestedExampleObjectRepository;
        private readonly DemoNestedExampleObjectsBuilder _DemoNestedExampleObjectsBuilder;

        public DemoInitialiser
        (
            AnotherAggregateRootRepository anotherAggregateRootRepository,
            DemoAnotherAggregateRootsBuilder demoAnotherAggregateRootsBuilder,

            NestedExampleObjectRepository nestedExampleObjectRepository,
            DemoNestedExampleObjectsBuilder demoNestedExampleObjectsBuilder,

            SaveableAggregateRootRepository saveableAggregateRootRepository,
            DemoSaveableAggregateRootsBuilder demoSaveableAggregateRootsBuilder,

            SaveableEntityRepository saveableEntityRepository,
            DemoSaveableEntitiesBuilder demoSaveableEntitiesBuilder,

            ObjectWithEagerLoadedPropertiesRepository objectWithEagerLoadedPropertiesRepository,
            ObjectWithEagerLoadedPropertiesBuilder demoObjectWithEagerLoadedPropertiesBuilder
        )
        {
            _AnotherAggregateRootRepository = anotherAggregateRootRepository;
            _DemoAnotherAggregateRootsBuilder = demoAnotherAggregateRootsBuilder;
            _NestedExampleObjectRepository = nestedExampleObjectRepository;
            _DemoNestedExampleObjectsBuilder = demoNestedExampleObjectsBuilder;
            _SaveableAggregateRootRepository = saveableAggregateRootRepository;
            _DemoSaveableAggregateRootsBuilder = demoSaveableAggregateRootsBuilder;
            _SaveableEntityRepository = saveableEntityRepository;
            _DemoSaveableEntitiesBuilder = demoSaveableEntitiesBuilder;
            _ObjectWithEagerLoadedPropertiesRepository = objectWithEagerLoadedPropertiesRepository;
            _DemoObjectWithEagerLoadedPropertiesBuilder = demoObjectWithEagerLoadedPropertiesBuilder;
        }

        public async Task SetupDemoDataAsync()
        {
            if (!_AnotherAggregateRootRepository.GetQuery().Any())
                await SaveToRepo(_AnotherAggregateRootRepository, _DemoAnotherAggregateRootsBuilder.Build());

            if (!_NestedExampleObjectRepository.GetQuery().Any())
                await SaveToRepo(_NestedExampleObjectRepository, _DemoNestedExampleObjectsBuilder.Build());

            if (!_SaveableAggregateRootRepository.GetQuery().Any())
                await SaveToRepo(_SaveableAggregateRootRepository, _DemoSaveableAggregateRootsBuilder.Build());

            if (!_SaveableEntityRepository.GetQuery().Any())
                await SaveToRepo(_SaveableEntityRepository, _DemoSaveableEntitiesBuilder.Build());

            if (!_ObjectWithEagerLoadedPropertiesRepository.GetQuery().Any())
                await SaveToRepo(_ObjectWithEagerLoadedPropertiesRepository, _DemoObjectWithEagerLoadedPropertiesBuilder.Build());
        }

        private async Task SaveToRepo<T>(IRepository<T> repo, IEnumerable<T> items)
            where T : class
        {
            foreach (var singleItem in items)
            {
                await repo.SaveAsync(singleItem, new[] { singleItem }, Array.Empty<object>(), Array.Empty<object>());
            }
        }
    }
}
