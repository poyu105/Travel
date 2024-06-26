﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Travel.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TravelUser class
public class TravelUser : IdentityUser
{
    public bool Admin { get; set; } = false;
    public string IdNumber { get; set; }
}

