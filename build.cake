#addin Cake.Npm

var target = Argument("target", "Default");

var apiBasePath = "./src/Zuehlke.StatisticsService.Api";

Task("Restore:Api")
  .Does(() =>
{
  Npm.FromPath(apiBasePath).Install();
});

Task("Build:Api")
  .IsDependentOn("Restore:Api")
  .Does(() =>
{
 Npm.FromPath(apiBasePath).RunScript("build");
});

Task("Build")
  .IsDependentOn("Build:Api")
  .Does(() =>
{
  var npmRunBuildProcessSettings = new ProcessSettings {
	Arguments = "run build",
	WorkingDirectory = apiBasePath
  };

  StartProcess("npm", npmRunBuildProcessSettings);
});

Task("Default")
  .IsDependentOn("Build")
  .Does(() =>
{
});

RunTarget(target);
