// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Windows.Forms;

// WinForms needs STA:
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

Type myDomainClass = typeof(ExampleBasicObject);

var mainForm =
    new BlazorWinFormBuilder()
    .WithModelAssembly(myDomainClass.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithServices(sc =>
    {
        sc.AddModelDependencies();
    })
    .WithPreStartupSteps(async sp =>
    {
        // This lets us setup demo data before the application starts:
        var demoInitialiser = sp.GetService<DemoInitialiser>();
        if (demoInitialiser != null)
        {
            await demoInitialiser.SetupDemoDataAsync();
        }
    })
    .Build();

Application.Run(mainForm);
