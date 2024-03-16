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
        private readonly ExamplesOfEagerLoadedPropertiesRepository _ExamplesOfEagerLoadedPropertiesRepository;
        private readonly DemoExamplesOfEagerLoadedPropertiesBuilder _DemoExamplesOfEagerLoadedPropertiesBuilder;
        private readonly DemoSaveableEntitiesBuilder _DemoSaveableEntitiesBuilder;
        private readonly ExampleAggregateRootRepository _ExampleAggregateRootRepository;
        private readonly DemoExampleAggregateRootsBuilder _DemoExampleAggregateRootsBuilder;
        private readonly ExampleOfNestedObjectsRepository _ExampleOfNestedObjectsRepository;
        private readonly DemoExampleOfNestedObjectsBuilder _DemoExampleOfNestedObjectsBuilder;

        public DemoInitialiser
        (
            ExampleAggregateRootRepository anotherAggregateRootRepository,
            DemoExampleAggregateRootsBuilder demoExampleAggregateRootsBuilder,

            ExampleOfNestedObjectsRepository nestedExampleObjectRepository,
            DemoExampleOfNestedObjectsBuilder demoExampleOfNestedObjectsBuilder,

            SaveableAggregateRootRepository saveableAggregateRootRepository,
            DemoSaveableAggregateRootsBuilder demoSaveableAggregateRootsBuilder,

            SaveableEntityRepository saveableEntityRepository,
            DemoSaveableEntitiesBuilder demoSaveableEntitiesBuilder,

            ExamplesOfEagerLoadedPropertiesRepository examplesOfEagerLoadedPropertiesRepository,
            DemoExamplesOfEagerLoadedPropertiesBuilder demoExamplesOfEagerLoadedPropertiesBuilder
        )
        {
            _ExampleAggregateRootRepository = anotherAggregateRootRepository;
            _DemoExampleAggregateRootsBuilder = demoExampleAggregateRootsBuilder;
            _ExampleOfNestedObjectsRepository = nestedExampleObjectRepository;
            _DemoExampleOfNestedObjectsBuilder = demoExampleOfNestedObjectsBuilder;
            _SaveableAggregateRootRepository = saveableAggregateRootRepository;
            _DemoSaveableAggregateRootsBuilder = demoSaveableAggregateRootsBuilder;
            _SaveableEntityRepository = saveableEntityRepository;
            _DemoSaveableEntitiesBuilder = demoSaveableEntitiesBuilder;
            _ExamplesOfEagerLoadedPropertiesRepository = examplesOfEagerLoadedPropertiesRepository;
            _DemoExamplesOfEagerLoadedPropertiesBuilder = demoExamplesOfEagerLoadedPropertiesBuilder;
        }

        public async Task SetupDemoDataAsync()
        {
            if (!_ExampleAggregateRootRepository.GetQuery().Any())
                await SaveToRepo(_ExampleAggregateRootRepository, _DemoExampleAggregateRootsBuilder.Build());

            if (!_ExampleOfNestedObjectsRepository.GetQuery().Any())
                await SaveToRepo(_ExampleOfNestedObjectsRepository, _DemoExampleOfNestedObjectsBuilder.Build());

            if (!_SaveableEntityRepository.GetQuery().Any())
                await SaveToRepo(_SaveableEntityRepository, _DemoSaveableEntitiesBuilder.Build());

            if (!_SaveableAggregateRootRepository.GetQuery().Any())
                await SaveToRepo(_SaveableAggregateRootRepository, _DemoSaveableAggregateRootsBuilder.Build());

            if (!_ExamplesOfEagerLoadedPropertiesRepository.GetQuery().Any())
                await SaveToRepo(_ExamplesOfEagerLoadedPropertiesRepository, _DemoExamplesOfEagerLoadedPropertiesBuilder.Build());
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
