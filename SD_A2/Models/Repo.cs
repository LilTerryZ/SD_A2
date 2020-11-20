using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_A2.Models
{
    public static class Repo
    {
        private static List<Drinks> responses = new List<Drinks>();

        public static IEnumerable<Drinks> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(Drinks response)
        {
            responses.Add(response);
        }

 
    }
}
