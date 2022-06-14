using System;

namespace Assi3
{
    //interface for the server
    interface AbstractServer
    {
        //accepts a visitor
        bool Accept(ServerQuery serverQuery);
    }
}
