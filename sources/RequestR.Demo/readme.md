# Demo Application

## Important classes

There are three important classes that are created in this demo:

- **The request**
  - class: `PresentProductsRequest`
  - namespace: `DustInTheWind.RequestBus.Demo.Application.PresentProducts`
  - This is the request class used from the presentation layer to trigger the execution of the Present Products use case.
  
- **The handler**
  - class: `PresentProductsRequestHandler`
  - namespace: `DustInTheWind.RequestBus.Demo.Application.PresentProducts`
  - This class will handle the request (`PresentProductsRequest`).
  - It is the actual implementation of the use case.
- **The command**
  - class: `ProductsCommand`
  - namespace: `DustInTheWind.RequestBus.Demo.Presentation.Commands`
  - This class is using the request bus to send the request (`PresentProgramsRequest`).

## Optional classes

- **The validator**
  - class: `PresentProductsRequestValidator`
  - namespace: `DustInTheWind.RequestBus.Demo.Application.PresentProducts`
  - If some validation is needed for the request object, it can be placed here.