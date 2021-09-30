
### How to start work with SignalR


- Add SignalR package to *.csproj :
``` 
<PackageReference Include="Microsoft.AspNetCore.SignalR" />
```

- Install signalr.js :
```
npm init -y  (to add package.json)

npm install @aspnet/signalr
```

- Copy signalr.js :
```
"../node_modules/@aspnet/signalr/dist/browser/"  -->  "~/lib/"
```
 