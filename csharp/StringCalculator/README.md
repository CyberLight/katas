Instructions
============
##### Information about files

* ```install-dependencies.cmd``` - command file for running downloading and resolving dependencies of projects using NuGet.exe
* ```run-tests.cmd``` - command file for running tests of kata StringCalculator
* ```buildplans\run-tests.build``` - MSBuild build plan for rebuilding and running tests
* ```run-tests.targets``` - Properties of ```run-tests.build```. You must replace ```[Path to xunit's folder with slash at end]```
placeholder with actual path to XUnit folder which contains ```xunit.runner.msbuild.dll``` dll (Please do this before runing tests).
* ```buildplans\install-deps.build``` - MSBuild build plan for automatically downloading dependencies from NuGet Repository.

* * * 

##### Steps to run kata's tests 

Before rannig tests, please introduce the following steps:
+ Run ```install-dependencies.cmd``` for donwnloading dependencies.
+ Open ```run-tests.targets``` with appropriate editor and replace ```[Path to xunit's folder with slash at end]``` placeholder with path to XUnit's folder.
+ Run ```run-tests.cmd``` for runnig all kata's tests.

* * *

