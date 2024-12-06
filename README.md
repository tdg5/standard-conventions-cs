# Standard Conventions for C#

Library for enforcing my preferred conventions in C#.

## Installation

The easiest way to install this package is to add a line something like the
following to your `.csproj` file:

```xml
<PackageReference Include="Tdg5.StandardConventions" PrivateAssets="all" Version="0.0.2" />
```

It's important that you include `PrivateAssets="all"` to avoid including
analyzers and other development packages in your run-time builds.


## Overriding configurations

Since this project provides global configurations, most configurations can be
overridden by adding a `.editorconfig` file to your project with your desired
overrides. Learn more here: [Configuration files for code analysis
rules](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/configuration-files).


## Running Tests

Test are run against packed versions of the library. Because of this, NuGet
caching can get in the way of tests seeing updates. To get around run the
following script to rebuild and run tests:

```bash
HARD=true ./scripts/clean-and-test.sh
```
