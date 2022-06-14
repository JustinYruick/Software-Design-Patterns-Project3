using System;

namespace Assi3
{
    //a class to multiply payload by 4
    class Multiply4Route : Route
    {
        //constructor that takes from Route base class
        public Multiply4Route(string path, Route next = null) : base(path, next) {}


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
            //returs the number *4
            int returnValue = value * 4;
            return returnValue; ;
        }
    }
}
