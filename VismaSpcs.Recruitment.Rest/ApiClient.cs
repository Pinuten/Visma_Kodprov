using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaSpcs.Recruitment.Rest
{
    internal class ApiClient
    {
        /// <summary>
        /// Fetches a defined entity from external resource (REST-api) and returns it.
        /// </summary>
        /// <typeparam name="T">Defined type, should NOT be object.</typeparam>
        /// <returns>An object of defined type.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> GetObjects<T>()
        {
            throw new NotImplementedException();
        }
    }
}
