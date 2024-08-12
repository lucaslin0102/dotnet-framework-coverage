[.NET test coverage - Coverlet](https://docs.sonarsource.com/sonarqube/latest/analyzing-source-code/test-coverage/dotnet-test-coverage/#coverlet)


Below is the sample SonarQubue Analysis command and test command to collect the coverage report using the dotnet tool, `coverlet.console`, in `opencover` format.
Since it is .Net Framework project, coverlet tool will target to `vstest.console.exe`.

```
SonarScanner.MSBuild.exe begin /k:"s4net-framework-analysis" /d:sonar.host.url=http://localhost:9000 /d:sonar.token="<sonar-token>" /d:sonar.cs.opencover.reportsPaths=**/coverage.opencover.xml

MSBuild.exe [your absolute path]\dotnet-framework-coverage\dotnet-framework.sln /t:Rebuild

coverlet .\dotnet-frameworktests\bin\Debug\net8.0\dotnet-frameworktests.dll --target "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" --targetargs ".\dotnet-frameworktests\bin\Debug\net8.0\dotnet-frameworktests.dll" --format "opencover" --output .\coverage-reports\

SonarScanner.MSBuild.exe end /d:sonar.token="<sonar-token>"
```