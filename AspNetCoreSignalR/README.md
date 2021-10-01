
# How to start work with SignalR

#### Add SignalR package to *.csproj :
``` 
		<PackageReference Include="Microsoft.AspNetCore.SignalR" />
```

#### Install signalr.js :
```
		npm init -y  (to add package.json)

		npm install @aspnet/signalr
```

#### Copy signalr.js :
```
		"../node_modules/@aspnet/signalr/dist/browser/"  -->  "~/lib/"
```

## Part 2. Use Redis.

```
		docker pull redis

		docker run --name signalr -d -p 6379:6379 redis
```

#### Add SignalR.Redis package to *.csproj :
``` 
		<PackageReference Include="Microsoft.AspNetCore.SignalR.Redis" />
```

#### Extend Startup.cs :
```
		services.AddSignalR(); ==> services.AddSignalR().AddRedis( ...
```

#### Connect to docker instance :
```
		docker ps
		
		docker exec -it b3 bash
		
		>/	redis-cli
		
		client list
```