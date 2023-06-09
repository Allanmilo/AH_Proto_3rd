﻿using System;
using System.IO;

using Codice.Client.Common;
using Codice.Utils;
using Unity.PlasticSCM.Editor.Tool;

namespace Unity.PlasticSCM.Editor
{
    internal static class UnityConfigurationChecker
    {
        internal static bool NeedsConfiguration()
        {
            string plasticClientBinDir = PlasticInstallPath.GetClientBinDir();

            if (string.IsNullOrEmpty(plasticClientBinDir))
                return true;

            SetupUnityEditionToken.FromPlasticInstallation(plasticClientBinDir);

            return ConfigurationChecker.NeedConfiguration();
        }
    }

    internal static class SetupUnityEditionToken
    {
        internal static void CreateCloudEditionTokenIfNeeded()
        {
            string toolPath = PlasticInstallPath.GetPlasticExePath();

            if (!string.IsNullOrEmpty(toolPath))
                return;

            string tokenFilePath = UserConfigFolder.GetConfigFile(
                EditionToken.CLOUD_EDITION_FILE_NAME);

            File.Create(tokenFilePath).Dispose();
        }

        internal static void FromPlasticInstallation(string plasticClientBinDir)
        {
            bool isCloudPlasticInstall = IsPlasticInstallOfEdition(
                plasticClientBinDir,
                EditionToken.CLOUD_EDITION_FILE_NAME);

            bool isDvcsPlasticInstall = IsPlasticInstallOfEdition(
                plasticClientBinDir,
                EditionToken.DVCS_EDITION_FILE_NAME);

            SetupTokenFiles(
                isCloudPlasticInstall,
                isDvcsPlasticInstall);
        }

        static void SetupTokenFiles(
            bool isCloudPlasticInstall,
            bool isDvcsPlasticInstall)
        {
            string unityCloudEditionTokenFile = UserConfigFolder.GetConfigFile(
                EditionToken.CLOUD_EDITION_FILE_NAME);

            string unityDvcsEditionTokenFile = UserConfigFolder.GetConfigFile(
                EditionToken.DVCS_EDITION_FILE_NAME);

            CreateOrDeleteTokenFile(isCloudPlasticInstall, unityCloudEditionTokenFile);
            CreateOrDeleteTokenFile(isDvcsPlasticInstall, unityDvcsEditionTokenFile);
        }

        static void CreateOrDeleteTokenFile(bool isEdition, string editionTokenFile)
        {
            if (isEdition && !File.Exists(editionTokenFile))
            {
                File.Create(editionTokenFile).Dispose();

                return;
            }

            if (!isEdition && File.Exists(editionTokenFile))
            {
                File.Delete(editionTokenFile);

                return;
            }
        }

        static bool IsPlasticInstallOfEdition(
            string plasticClientBinDir,
            string editionFileName)
        {
            return File.Exists(Path.Combine(
                plasticClientBinDir,
                editionFileName));
        }
    }
}
