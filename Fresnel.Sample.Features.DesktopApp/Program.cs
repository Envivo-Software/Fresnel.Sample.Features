// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.Bootstrap;
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
                .WithModelAssembly(domainClassType.Assembly)
                .Build();

            Application.Run(mainForm);
        }
    }
}