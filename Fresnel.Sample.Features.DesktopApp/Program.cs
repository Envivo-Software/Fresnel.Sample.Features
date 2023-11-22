// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows.Forms;

// WinForms needs STA:
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

Type myDomainClass = typeof(BasicObject);

var serviceCollection = new ServiceCollection();
// Override (or register) dependencies here:
serviceCollection.AddSingleton<SaveableAggregateRootRepository>();
serviceCollection.AddSingleton<SaveableEntityRepository>();
serviceCollection.AddSingleton<AnotherAggregateRootRepository>();
serviceCollection.AddSingleton<NestedExampleObjectRepository>();

var builder = new BlazorWinFormBuilder();
var mainForm =
    builder
    .WithServices(serviceCollection)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithModelAssembly(myDomainClass.Assembly)
    .Build();

var demoInitialiser = builder.BuildServiceProvider().GetService<DemoInitialiser>();
await demoInitialiser.SetupDemoDataAsync();

Application.Run(mainForm);
