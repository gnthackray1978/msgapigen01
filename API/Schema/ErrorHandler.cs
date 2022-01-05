﻿using GqlMovies.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GqlMovies.Api.Schemas
{
    public class ErrorHandler {
		public static async Task<Results<T>> Error<T>(Exception xerror, string loginInfo) where T : class
		{
			string error = "No User";

			if (xerror != null)
				error = xerror.Message;


			var results = new Results<T>();

			results.results = new List<T>();

			results.LoginInfo = loginInfo;
			results.Error = error;

			results.total_results = 0;

			return results;
		}


	}
}