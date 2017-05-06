#addin Cake.Yarn

var target = Argument("target", "Default");

var apiBasePath = "./src/Zuehlke.StatisticsService.Api";

Task("Restore:Api")
  .Does(() =>
{
  Yarn.FromPath(apiBasePath).Install();
});

Task("Build:Api")
  .IsDependentOn("Restore:Api")
  .Does(() =>
{
 Yarn.FromPath(apiBasePath).RunScript("build");
});

Task("Build")
  .IsDependentOn("Build:Api")
  .Does(() =>
{
});

Task("Start")
  .Does(() =>
{
  Yarn.FromPath(apiBasePath).RunScript("life");
});

Task("Default")
  .IsDependentOn("Build")
  .Does(() =>
{
});

RunTarget(target);
