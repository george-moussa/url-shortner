dotnet publish -c Release -o ./bin/Publish

Push-Location ./bin/Publish

Compress-Archive -Path * -DestinationPath package.zip -Force

az account set -s d432afea-9680-44af-b5b7-6967919419f4

az webapp deploy --resource-group cap --name cap-url-shortner --src-path package.zip

Pop-Location

