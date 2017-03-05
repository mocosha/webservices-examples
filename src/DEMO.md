# Introduction
## Motivation
### Monolithic application
In software engineering, a monolithic application describes a single-tiered software application in which the user interface and data access code are combined into a single program from a single platform.
### System integration
In engineering, system integration is defined as the process of bringing together the component sub-systems into one system (an aggregation of subsystems cooperating so that the system is able to deliver the overarching functionality) and ensuring that the subsystems function together as a system. In information technology, systems integration[2] is the process of linking together different computing systems and software applications physically or functionally,[3] to act as a coordinated whole.

### World wide web
- Designed for human-application interactions
- No support for application-application interactions

## Web services
- Enables applications to expose their services "programmatically", i.e. the services can be invoked by programs
- Enables software running on other computers (could be a desktop, mobile phone, etc.) to invoke operations exposed by Web applications
- Built on top of underlying protocols and mechanisms for web (e.g., HTTP) 

## Scenarios for web services
### Allowing programmatic access to applications accessed over the Internet
- B2B integration – allowing applications from different organizations to communicate across the Internet
- A2A integration – allowing applications within an organization to communicate across an intranet 

### Web Services Technology
Two competing approaches REST-style vs SOAP-based.

### SOAP
SOAP specification can be broadly defined to be consisting of the following 3 conceptual components: Protocol concepts, encapsulation concepts and Network concepts.
- XML: Describing information sent over the network (Envelope, [Header], Body, [Fault])
- WSDL: Defining Web service capability (Web Services Description Language)
- SOAP: Accessing Web services
- UDDI: Finding web services

### REST
Representational state transfer (REST) or RESTful Web services are one way of providing interoperability between computer systems on the Internet. REST-compliant Web services allow requesting systems to access and manipulate textual representations of Web resources using a uniform and predefined set of stateless operations.  In a RESTful Web service, requests made to a resource's URI will elicit a response that may be in XML, HTML, JSON or some other defined format.

Design philosophy
- Everything on the web is a resource with a URI
- HTTP is not just a transport protocol
- It provides an API (POST, GET, PUT, DELETE) for Create, Read, Update, and Delete operations on a resource
- Approach isolates application complexity at the end points (client and server) and keeps it out of the transport 
 
# Demo
## Consuming a SOAP web service
- Navigate to http://localhost:50051/SimpleService.svc
- WCF Test Client "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\WcfTestClient.exe"

### Console client
- Add Service Reference parses the WSDL of the service to import the service contract, and potentially any referenced domain types, into the client's representation (in this case, C#). It generates a proxy which exposes a C# interface that represents the service contract. The proxy is a namespace and set of classes with methods to call each service method for the particular endpoint.

        In short it takes service contract metadata and reifies it to C#.
        
        You can also manually generate the proxy with 'svcutil.exe'

        svcutil http://server.com/FooService/FooService.svc /out:FooProxy.cs
        Or to include generation of the app.config as well

        svcutil http://server.com/FooService /out:FooProxy.cs /config:App.config
- Customize endpoint

### Soap UI

## Key-value store library
Simple in-memory key value store Library, for educational purpose only :)

Possible improvements:
- Tests
- Nuget

## Creating a simple WCF Service
Windows Communication Foundation (WCF) is Microsoft’s unified programming model for building service-oriented applications. 
### New project
Visual Studio 2015: File / Add / New Project... / WCF Service Application
- Bindings (basicHttpBinding / webHttpBinding)
- Endpoints
- Data contract

WCF can be hosted in IIS or self-hosted in any managed .NET application.

### Web service example
- Clone repo https://github.com/mocosha/webservices-examples.git
- Go through projects / code

## Creating a simple WebApi service
ASP.NET Web API is a framework for building web APIs on top of the .NET Framework.
Basically, a Web API controller is an MVC controller, which uses HttpMessageResponse as the base type of its response, instead of ActionResponse.
UPDATE: For ASP.NET Core, Web API has been integrated into the MVC 6 project type and the ApiController class is consolidated into the Controller class.

- Response: JSON / XML
- Swagger
- Postman

## Tools
- [Soap UI](https://www.soapui.org/); The Most Advanced REST & SOAP Testing Tool in the World
- [Fiddler](http://www.telerik.com/fiddler); The free web debugging proxy for any browser, system or platform
- [Postman](https://www.getpostman.com/); Developing APIs is hard. Postman makes it easy.
- [Swagger](http://swagger.io/), [ASP.NET Web API Help Pages using Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger)

## Resources
- [SOAP Version 1.2 Part 1: Messaging Framework (Second Edition)](https://www.w3.org/TR/soap12-part1/)
- [Into to Web Services CS 475](http://cs.gmu.edu/~setia/cs475/slides/lecture17.pdf)
- https://www.wikipedia.org/
- http://stackoverflow.com/questions/26558944/what-does-add-service-reference-really-do