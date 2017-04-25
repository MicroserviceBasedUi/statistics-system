 #addin "Cake.Npm"

var target = Argument("target", "Default");

var apiBasePath = "./src/Zuehlke.StatisticsService.Api";

Task("Restore:Api")
  .Does(() =>
{
  var processSettings = new ProcessSettings {
	Arguments = "install",
	WorkingDirectory = apiBasePath
  };

  StartProcess("npm", processSettings);
});

Task("Build:Api")
  .IsDependentOn("Restore:Api")
  .Does(() =>
{
  var npmInstallProcessSettings = new ProcessSettings {
	Arguments = "install",
	WorkingDirectory = apiBasePath
  };

  StartProcess("npm", npmInstallProcessSettings);
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
