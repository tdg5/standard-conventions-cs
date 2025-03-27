#!/bin/bash

ROOT_PROJECT_PATH="$ROOT_PROJECT_PATH"
echo "$ROOT_PROJECT_PATH"

export ROOT_PROJECT_PATH

TEST_ARTIFACTS_PATH="$HOME/.cache/Tdg5.StandardConventions.Tests/test-artifacts"
rm -rf "$TEST_ARTIFACTS_PATH"
find . -type d \( -name bin -o -name obj \) -print0 | xargs -0 rm -rf

if [ -n "$HARD" ]; then
  # Try to preserve other caches to minimize restore time.
  dotnet nuget locals global-packages --clear
fi

dotnet clean

ROOT_PROJECT_PATH="$ROOT_PROJECT_PATH" dotnet test --logger "console;verbosity=detailed"
