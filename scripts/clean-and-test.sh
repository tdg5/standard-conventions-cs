#!/bin/bash

TEST_ARTIFACTS_PATH="$HOME/.cache/Tdg5.StandardConventions.Tests/test-artifacts"
rm -rf "$TEST_ARTIFACTS_PATH"
find . -type d \( -name bin -o -name obj \) -print0 | xargs -0 rm -rf

if [ -n "$HARD" ]; then
  # Try to preserve other caches to minimize restore time.
  dotnet nuget locals global-packages --clear
fi

dotnet clean

dotnet test --logger "console;verbosity=detailed"
