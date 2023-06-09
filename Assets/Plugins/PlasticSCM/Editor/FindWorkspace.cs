﻿using System.IO;

using Codice.Client.Common;
using Codice.CM.Common;
using PlasticGui;

namespace Unity.PlasticSCM.Editor
{
    internal static class FindWorkspace
    {
        internal static string PathForApplicationPath(string path)
        {
            return FindWorkspacePath(
                path, ClientConfig.Get().GetWkConfigDir());
        }

        internal static WorkspaceInfo InfoForApplicationPath(
            string path, IPlasticAPI plasticApi)
        {
            string wkPath = PathForApplicationPath(path);

            if (string.IsNullOrEmpty(wkPath))
                return null;

            return plasticApi.GetWorkspaceFromPath(wkPath);
        }

        static string FindWorkspacePath(string path, string wkConfigDir)
        {
            while (!string.IsNullOrEmpty(path))
            {
                if (Directory.Exists(Path.Combine(path, wkConfigDir)))
                    return path;

                path = Path.GetDirectoryName(path);
            }

            return null;
        }
    }
}
