del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack ToSic.Module.AnalyzeServiceLifetimes.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

