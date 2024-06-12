# ASP.NET 
### ASP.NET is the framework in .net used for building web applications

#### ASP.NET CORE Web API
##### API : application programming interface
****

* HTTP/HTTPS
* Status Codes
* Http Methods
* Request, Response
* Middlewares
* Dependency Injection
* Life Cycles

***
## HTTP/HTTPS
~~~
$ HTTP: Hypertext Transfer Protocol 
$ HTTPS: Hypertext Transfer Protocol Secure
$ SSL : Secure Socket Layer
~~~

## STATUS CODES
### These are codes returned with HTTP responses... They define the respone gotten form a server
~~~
100s, 200s, 300s, 400s, 500s
~~~

## HTTP Methods
~~~
$ POST --- Create
$ GET --- Read
$ PUT --- Update
$ DELETE --- Delete
$ PATCH --- Update
~~~

## Middleware
###

## Dependency  Lifetimes

~~~
$ Singleton : One instance is created for a resource and all requests make use of that instance
$ Scoped : One instance is created for a resource, however, for one request
$ Transient : One instance per request
~~~