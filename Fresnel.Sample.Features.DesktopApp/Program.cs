// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Windows.Forms;

// WinForms needs STA:
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

ApplicationConfiguration.Initialize();

var builder = new HostApplicationBuilder(args);

builder.AddFresnel(opt =>
{
    opt
    .WithModelAssemblyFrom<ExampleBasicObject>()
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithFeature(Feature.UI_UserFeedback, FeatureState.On)
    .WithDefaultFileLogging()
    ;

    builder.Services.AddModelDependencies();
});

var host = builder.Build();

host.UseFresnel();

// Setup demo data before the application starts:
var demoInitialiser = host.Services.GetService<DemoInitialiser>();
if (demoInitialiser != null)
{
    await demoInitialiser.SetupDemoDataAsync();
}

var mainForm = host.Services.GetService<BlazorWinForm>() ?? throw new NullReferenceException();
Application.Run(mainForm);
