using Api.Types.Diagrams;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Schema
{
    public class ErrorHandler
    {
        public static async Task<Results<T>> Error<T>(Exception xerror, string loginInfo) where T : class
        {
            string error = "No User";

            if (xerror != null)
                error = xerror.Message;


            var results = new Results<T>();

            results.rows = new List<T>();

            results.LoginInfo = loginInfo;
            results.Error = error;

            results.total_rows = 0;

            return results;
        }

        public static async Task<DiagramResults<T>> DiagramError<T>(Exception xerror, string loginInfo) where T : class
        {
            string error = "No User";

            if (xerror != null)
                error = xerror.Message;


            var results = new DiagramResults<T>();

            results.rows = new List<T>();

            results.LoginInfo = loginInfo;
            results.Error = error;

            return results;
        }
    }
}