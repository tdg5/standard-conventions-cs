#!/bin/bash

TEST_ARTIFACTS_PATH="$HOME/.cache/Tdg5.StandardConventions.Tests/test-artifacts"
rm -rf "$TEST_ARTIFACTS_PATH"
find . -type d \( -name bin -o -name obj \) -print0 | xargs -0 rm -rf
[ -n "$HARD" ] && dotnet nuget locals all --clear
dotnet clean

dotnet test
