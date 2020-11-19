# Knowledge_Base
Just my own .Net and JS development Knowledge Base.


#### To run a .NET Core console application on Linux


1.Publish your application as a self contained application:

``` dotnet publish -c release -r ubuntu.16.04-x64 --self-contained

2. Copy the publish folder to the Ubuntu machine

3. Open the Ubuntu machine terminal (CLI) and go to the project directory

4. Provide execute permissions:

``` chmod 777 ./appname

5. Execute the application

``` ./appname

