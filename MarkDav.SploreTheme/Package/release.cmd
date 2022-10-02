"..\..\oqtane.framework\oqtane.package\nuget.exe" pack MarkDav.SploreTheme.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y
