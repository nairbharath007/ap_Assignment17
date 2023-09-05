using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Exceptions
{
    internal class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(string message) : base(message) { }
    }
}
