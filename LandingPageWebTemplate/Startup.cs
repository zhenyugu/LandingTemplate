﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LandingPageWebTemplate.Startup))]

namespace LandingPageWebTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
