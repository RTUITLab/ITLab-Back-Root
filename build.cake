var target = Argument("target", "BuildAll");
var configuration = Argument("configuration", "Release");


var cakeSettings = new CakeSettings 
{
   Arguments = new Dictionary<string, string>{
      ["configuration"] = configuration
   }
};

Task("BuildBack")
.Does(() => 
{
   CakeExecuteScript("./ITLab-Back/build.cake", cakeSettings);
});

Task("BuildIdentity")
.Does(() => 
{
   CakeExecuteScript("./ITLab-Identity/build.cake", cakeSettings);
});

Task("BuildAll")
   .IsDependentOn("BuildBack")
   .IsDependentOn("BuildIdentity")
   .Does(() =>
{
   
});

RunTarget(target);