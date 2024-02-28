// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Envivo.Fresnel.Sample.Features.Model.J_Services
{
    /// <summary>
    /// This Domain Services provide access to logic without instantiating an object
    /// </summary>
    public class ExampleDomainService : IDomainService
    {
        /// <summary>
        /// Uploads a file to the server
        /// </summary>
        /// <param name="file">Provide the file to be uploaded to the server</param>
        public void UploadFile(string file)
        {
        }

        public string DownloadFile()
        {
            return "Done!";
        }
    }
}