rm coverage.xml
rm unit-results.xml

pushd xunit.bug.tests
    ~/.nuget/packages/opencover/4.6.519/tools/OpenCover.Console.exe `
        -target:"dotnet.exe" `
        "-targetargs:xunit -xml ..\unit-results.xml" `
        -output:..\coverage.xml `
        "-filter:+[xunit.bug*]* -[xunit.bug.tests*]*" `
        -searchdirs:bin\Debug\netcoreapp1.1 `
        -register:user `
        -oldstyle
popd

