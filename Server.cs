﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSharper;
using WebSharper.Sitelets;
using WebSharper.UI.Next;
using WebSharper.UI.Next.CSharp;
using WebSharper.UI.Next.CSharp.Server;
using static WebSharper.UI.Next.CSharp.Html;

namespace JavascriptInlineError
{
    public class Server
    {
        [EndPoint("/")]
        public class Home { }

        [EndPoint("GET /about")]
        public class About { }


        public static Task<Content> Page(Context<object> ctx, object endpoint, string title, Doc body) =>
            Content.Page(
                new Template.Main()
                    .Title(title)
                    .Body(body)
                    .Doc()
            );

        [Website]
        public static Sitelet<object> Main =>
            new SiteletBuilder()
                .With<Home>((ctx, action) =>
                    Page(ctx, action, "Home",
                        doc(
                            h1("Say Hi to the server!"),
                            div(client(() => Client.Main()))
                        )
                    )
                )
                .With<About>((ctx, action) =>
                    Page(ctx, action, "About",
                        doc(
                            h1("About"),
                            p("This is a template WebSharper client-server application.")
                        )
                    )
                )
                .Install();
    }
}