using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using XPathEval.Models;

namespace XPathEval.Utils
{
    /*
        Adapted from : http://www.c-sharpcorner.com/UploadFile/201fc1/what-is-random-urls-and-how-to-creating-them-in-Asp-Net/
    */
    public static class UrlUtils
    {
        private static int[] numbers = Enumerable.Range(0, 10).ToArray();
        private static char[] characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-".ToCharArray();
        private const int length = 8;

        public static string GetUrl()
        {
            string url = "";
            Random rand = new Random();
            // run the loop till I get a string of certain `length`
            for (int i = 0; i <= length; i++)
            {
                // Get combination of random number and characters. composition 1 : 3
                int random = rand.Next(0, 3);
                if (random == 1)
                {
                    // use a number  
                    random = rand.Next(0, numbers.Length);
                    url += numbers[random].ToString();
                }
                else {
                    // use a number
                    random = rand.Next(0, characters.Length);
                    url += characters[random].ToString();
                }
            }
            return url;
        }

        public static string GetRedirectUrl(XPathDemoMongo model, RequestContext context)
        {
            UrlHelper urlHelper = new UrlHelper(context);
            if (model.Revision > 0)
                return urlHelper.Action("Index", "XPath", new { id = model.Id, rev = model.Revision });
            else
                return urlHelper.Action("Index", "XPath", new { id = model.Id });
        }
    }
}