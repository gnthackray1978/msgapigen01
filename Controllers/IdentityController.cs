﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;
using System.Diagnostics;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {


        public IActionResult Get()
        {         
            ClaimsPrincipal currentUser = this.User;

            Console.WriteLine("gotten");

            Debug.WriteLine("debug gotten");

            return new JsonResult(from c in currentUser.Claims select new { c.Type, c.Value});
        }
    }
}