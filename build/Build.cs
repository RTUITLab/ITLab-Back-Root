using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static SimpleExec.Command;

[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.BuildAll);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    AbsolutePath IdentityDirectory = RootDirectory / "ITLab-Identity";
    AbsolutePath BackDirectory = RootDirectory / "ITLab-Back";
    AbsolutePath DocsGenDirectory = RootDirectory / "ITLab-DocsGen";
    AbsolutePath NotifyDirectory = RootDirectory / "ITLab-Notify";

    Target BuildIdentity => _ => _
        .Executes(() =>
        {
            Run("nuke", workingDirectory: IdentityDirectory);
        });

    Target BuildBack => _ => _
        .Executes(() =>
        {
            Run("nuke", workingDirectory: BackDirectory);
        });

    Target BuildDocsGen => _ => _
        .Executes(() =>
        {
            Run("gradlew", "build",
                windowsName: "cmd", windowsArgs: "/c gradlew build",
                workingDirectory: DocsGenDirectory);
            Run("gradlew", "copyLibToDeploy",
                windowsName: "cmd", windowsArgs: "/c gradlew copyLibToDeploy",
                workingDirectory: DocsGenDirectory);
        });
    Target BuildNotify => _ => _
        .Executes(() =>
        {
            Run("gradlew", "build",
                windowsName: "cmd", windowsArgs: "/c gradlew build",
                workingDirectory: NotifyDirectory);
            Run("gradlew", "copyLibToDeploy",
                windowsName: "cmd", windowsArgs: "/c gradlew copyLibToDeploy",
                workingDirectory: NotifyDirectory);
        });

    Target BuildAll => _ => _
        .DependsOn(
            BuildIdentity,
            BuildBack,
            BuildDocsGen,
            BuildNotify)
        .Executes(() =>
        {
        });
}
