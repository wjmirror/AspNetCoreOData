﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using ODataMvcSample.Models;

namespace ODataMvcSample.Controllers
{
    public class MeController : ControllerBase
    {
        [HttpGet]
        public Customer Get()
        {
            return new Customer { Id = 9, Name = "Sam" };
        }

        [HttpGet]
        public VipCustomer GetMeFromVipCustomer()
        {
            return new VipCustomer { Id = 10, Name = "Peter", Emails = new List<string> { "abc@ef.com" } };
        }

        [HttpPost]
        [EnableQuery]
        public IActionResult BoundAction(ODataActionParameters parameters)
        {
            /*
{
    "p1": 1,
    "p2": { "Street": "1 Microsoft Way", "City": "Redmond" },
    "p3": [ "one", "two" ],
    "p4": [ { "Street": "1 Microsoft Way", "City": "Redmond" } ],
    "color": "Red",
    "colors": ["Red", null, "Green"]
}
            */

            return Ok($"BoundAction of Me: {System.Text.Json.JsonSerializer.Serialize(parameters)}");

            /*
            {
                "@odata.context": "http://localhost:5000/v1/Me/BoundAction/$metadata#Edm.String",
    "value": "BoundAction of Me: {\"p1\":1,\"p2\":{\"City\":\"Redmond\",\"Street\":\"1 Microsoft Way\"},\"p3\":[\"one\",\"two\"],\"p4\":[{\"City\":\"Redmond\",\"Street\":\"1 Microsoft Way\"}],\"color\":0,\"colors\":[0,null,1]}"
}
            */
        }
    }
}
