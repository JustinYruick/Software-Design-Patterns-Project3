using System;

namespace Assi3
{
    //a request class has a string Route and a Int payload
    class Request : Command
    {
        //basic 2 arg constructor
        public Request(string route, int payload) {
            Route = route;
            Payload = payload;
        }
        
        public string Route;
        public int Payload;

        //excutes the current request by calling the routes handle method
        public int Execute()
        {
            Route route = new Route(Route);
            return route.HandleRequest(Payload);
        }
    }
}
