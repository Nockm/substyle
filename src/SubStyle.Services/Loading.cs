﻿namespace SubStyle.Services;

using SubStyle.Models;

public static class Loading
{
    public static Workspace LoadWorkspace()
    {
        Paths paths = new Paths();

        return Loading.LoadWorkspaceFromPaths(paths);
    }

    public static Pack LoadPackFromDirectory(string directory)
    {
        string[] files = Directory.GetFiles(directory);

        List<Asset> assets = files.ToList().ConvertAll(Asset.PathToAsset);

        Pack pack = new Pack()
        {
            Name = directory,
        }.SetAssets(assets);

        return pack;
    }

    public static Workspace LoadWorkspaceFromPaths(Paths paths)
    {
        Pack rootPack = LoadPackFromDirectory(paths.DefaultGraphicsDir);

        Workspace workspace = new Workspace()
        {
            RootPack = rootPack,
        };

        return workspace;
    }
}