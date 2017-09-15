﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Chocolatey" file="IChocolateyService.cs">
//   Copyright 2014 - Present Rob Reynolds, the maintainers of Chocolatey, and RealDimensions Software, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using ChocolateyGui.Models;

namespace ChocolateyGui.Services
{
    using System.Collections.Generic;
    using NuGet;

    public interface IChocolateyService
    {
        Task<bool> IsElevated();

        Task<IEnumerable<Package>> GetInstalledPackages();

        Task<IReadOnlyList<Tuple<string, SemanticVersion>>> GetOutdatedPackages(bool includePrerelease = false);

        Task<PackageResults> Search(string query, PackageSearchOptions options);

        Task<Package> GetByVersionAndIdAsync(string id, string version, bool isPrerelease);

        Task<PackageOperationResult> InstallPackage(
            string id,
            string version = null,
            Uri source = null,
            bool force = false);

        Task<PackageOperationResult> UninstallPackage(string id, string version, bool force = false);

        Task<PackageOperationResult> UpdatePackage(string id, Uri source = null);

        Task<PackageOperationResult> PinPackage(string id, string version);

        Task<PackageOperationResult> UnpinPackage(string id, string version);

        Task<ChocolateyFeature[]> GetFeatures();

        Task SetFeature(ChocolateyFeature feature);

        Task<ChocolateySetting[]> GetSettings();

        Task SetSetting(ChocolateySetting setting);

        Task<ChocolateySource[]> GetSources();

        Task AddSource(ChocolateySource source);

        Task UpdateSource(string id, ChocolateySource source);

        Task<bool> RemoveSource(string id);
    }
}