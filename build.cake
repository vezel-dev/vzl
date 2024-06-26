#addin nuget:?package=Cake.DoInDirectory&version=6.0.0
#addin nuget:?package=Cake.Npm&version=4.0.0

#nullable enable

// Arguments

var target = Argument("t", "default");

// Paths

var doc = Context.Environment.WorkingDirectory.Combine("doc");

// Tasks

Task("default")
    .IsDependentOn("build");

Task("default-editor")
    .IsDependentOn("build");

Task("restore-doc")
    .Does(() => DoInDirectory(doc, () => NpmInstall()));

Task("restore")
    .IsDependentOn("restore-doc");

Task("build-doc")
    .IsDependentOn("restore-doc")
    .Does(() => DoInDirectory(doc, () => NpmRunScript("build")));

Task("build")
    .IsDependentOn("build-doc");

RunTarget(target);
