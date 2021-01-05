### To use ServiceModel Metadata Utility Tool (`scvutil`) should install previous version of dotnet Core :
```
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-2.1

sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-runtime-2.1
```
----------------------------------------------------

### 1. Install Scaffold Tool :
```
dotnet tool install --global dotnet-svcutil
```

### 2. Create Solution & Project :
```
dotnet new sln
$ mkdir src && cd src
dotnet new webapi -o BlaBlaBlaProj
cd ..
dotnet sln add src/BlaBlaBlaProj/BlaBlaBlaProj.csproj
```

### 3. Scaffolding Client From WSDL File :
```
cd src/BlaBlaBlaProj
dotnet-svcutil https://www.w3schools.com/xml/tempconvert.asmx?wsdl
```
( this must generate ../src/BlaBlaBlaProj/ServiceReference/Reference.cs )

### 4. Implement logic for Clients, Interfaces, Repositories ...
