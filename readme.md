# RequestR with Microsoft Dependency Injection - Getting Started

## 1) Setup Services

**Note**: Include `RequestR.Extensions.Microsoft.DependencyInjection` nuget package.

```csharp
ServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddRequestBus();
```

## 2) Setup the Request Bus

Retrieve the `RequestBus` instance and call the `RegisterAllHandlers()` method.

```csharp
RequestBus requestBus = serviceProvider.GetService<RequestBus>();
requestBus.RegisterAllHandlers();
```

## 3) Send request

```csharp
PresentProductsRequest request = new PresentProductsRequest();
MyResponse response = requestBus.Send<MyRequest, MyResponse>(request);
```
