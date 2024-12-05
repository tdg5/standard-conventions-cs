# Standard Conventions for C#

Library for enforcing my preferred conventions in C#.

## Running Tests

Test are run against packed versions of the library. Because of this, NuGet
caching can get in the way of tests seeing updates. To get around run the
following script to rebuild and run tests:

```bash
HARD=true ./scripts/clean-and-test.sh
```
