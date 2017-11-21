This repository reproduces a bug in xUnit when executed on .Net Core 1.1 under OpenCover.

Running the supplied `Run-Coverage.ps1` script in Powershell should execute the unit test successfully by starting up
the WebAPI project using `TestServer` and making a call to `/api/values`.

If the target framework is changed to `net461` then the test passes successfully. When targeting `netcoreapp1.1` though,
the test throws an exception because the `TestServer` fails to start due to the content root directory not being found.
This is because xUnit changes the current directory. A sample stack trace is:

```
    xunit.bug.tests.ValuesTests.Get_WhenCalled_ReturnsHttpSuccess [FAIL]
      System.ArgumentException : The content root 'C:\Users\adam\.nuget\packages\dotnet-xunit\2.3.0\tools\netcoreapp1.0\..\..\..\..\xunit.bug' does not exist.
      Parameter name: contentRootPath
      Stack Trace:
           at Microsoft.AspNetCore.Hosting.Internal.HostingEnvironmentExtensions.Initialize(IHostingEnvironment hostingEnvironment, String applicationName, String contentRootPath, WebHostOptions options)
           at Microsoft.AspNetCore.Hosting.WebHostBuilder.BuildCommonServices()
           at Microsoft.AspNetCore.Hosting.WebHostBuilder.Build()
           at Microsoft.AspNetCore.TestHost.TestServer..ctor(IWebHostBuilder builder)
        <snip>\xunit-bug\xunit.bug.tests\ValuesTests.cs(14,0): at xunit.bug.tests.ValuesTests.<Get_WhenCalled_ReturnsHttpSuccess>d__0.MoveNext()
```
