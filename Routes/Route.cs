using System;
using System.Linq;

namespace Assi3
{
    //rouute class to be inheireted by subclasses
    class Route
    {
        public Route Next;
        public string Path;

        //basic 2 args constructor
        public Route(string path, Route next = null) {
            this.Path = path;
            this.Next = next;
        }

        //sets the next route to follow COR
        public void setNext(Route next) {
            this.Next = next;
        }

        //handles the request 
        public virtual int HandleRequest(int payload)
        {
            //splits the path values and gets current path
            string[] pathValues = Path.Split('/');
            string currentPath = pathValues[0];
            pathValues = pathValues.Skip(1).ToArray();

            if (currentPath == "")
            {
                currentPath = pathValues[0];
                pathValues = pathValues.Skip(1).ToArray();
            }

            string newFullPath = string.Join("/", pathValues);

            //check the current path
            switch (currentPath)
            {
                case "add":
                    Next = new AddRoute(newFullPath);
                    break;
                case "mul":
                    Next = new MultiplyRoute(newFullPath);
                    break;
                case "4":
                    Next = new Multiply4Route(newFullPath);
                    break;
                default:
                    return 404;
            }

            if (Next != null)
            {
                //calls the next in line HandleRequest
                return Next.HandleRequest(payload);
            }

            return payload;
        }

    }
}
