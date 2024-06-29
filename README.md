Template project
root-folder> dotnet pack --output <path-to-output-directory> #generate the .nupkg file in order to share for template installation

root-folder>dotnet new --install .

dotnet new customtemplate -o "NameOfTheProject"

Creates a basic .net(8 by default) Web API project using Clean Architecture with CQRS
