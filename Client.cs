using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSharper;
using WebSharper.UI.Next;
using WebSharper.UI.Next.Client;
using WebSharper.UI.Next.CSharp;
using WebSharper.UI.Next.CSharp.Client;
using Microsoft.FSharp.Core;
using static WebSharper.UI.Next.CSharp.Client.Html;

namespace JavascriptInlineError
{
    [JavaScript]
    public static class Client
    {
        static Var<string> vr = Var.Create("");

        [Inline("parseInt($s)")]
        public static int ParseInt(string s) { return 0; }

        public static async void parse()
        {
            (ParseInt("12345") + 1).ToString();
        }

        static public IControlBody Main()
        {
            return div(
            );
        }
    }
}