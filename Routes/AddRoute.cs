using System;

namespace Assi3
{
    //a route that adds 8 the given number
    class AddRoute : Route
    {
        //constructor that takes from Route base class
        public AddRoute(string path, Route next = null) : base(path, next) {}

        //overrides handle Request
        public override int HandleRequest(int value)
        {
            //checks if next is there and call its hanlde method
            if (Next != null)
            {
                return Next.HandleRequest(value);
            }

            if (Path != "")
            {
                return base.HandleRequest(value);
            }
            //returs the number + 8
            int returnValue = value + 8;
            return returnValue; ;
        }
    }
}
