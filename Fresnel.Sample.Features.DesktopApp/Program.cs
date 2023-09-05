// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap.WinForms;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Envivo.Fresnel.Sample.Features.DesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceCollection = new ServiceCollection();
            // Register your own dependencies here

            var domainClassType = typeof(BasicObject);

            var mainForm =
                new BlazorWinFormBuilder()
                .WithServices(serviceCollection)
                //.WithFeature(Feature.UI_DoodleMode, FeatureState.On)
                .WithModelAssembly(domainClassType.Assembly)
                .Build();

            Application.Run(mainForm);
        }
    }
}