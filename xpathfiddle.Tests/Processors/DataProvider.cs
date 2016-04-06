﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPathEval.Tests.Processors
{
    public static class DataProvider
    {
        public static string GetInventorySample()
        {
            //taken from https://msdn.microsoft.com/en-us/library/ms256095%28v=vs.110%29.aspx
            return @"<bookstore specialty=""novel"">
  <book style=""autobiography"">
    <author>
      <first-name>Joe</first-name>
      <last-name>Bob</last-name>
      <award>Trenton Literary Review Honorable Mention</award>
    </author>
    <price>12</price>
  </book>
  <book style=""textbook"">
    <author>
      <first-name>Mary</first-name>
      <last-name>Bob</last-name>
      <publication>Selected Short Stories of
        <first-name>Mary</first-name>
        <last-name>Bob</last-name>
      </publication>
    </author>
    <editor>
      <first-name>Britney</first-name>
      <last-name>Bob</last-name>
    </editor>
    <price>55</price>
  </book>
  <magazine style=""glossy"" frequency=""monthly"">
    <price>2.50</price>
    <subscription price=""24"" per=""year""/>
  </magazine>
  <book style=""novel"" id=""myfave"">
    <author>
      <first-name>Toni</first-name>
      <last-name>Bob</last-name>
      <degree from=""Trenton U"">B.A.</degree>
      <degree from=""Harvard"">Ph.D.</degree>
      <award>Pulitzer</award>
      <publication>Still in Trenton</publication>
      <publication>Trenton Forever</publication>
    </author>
    <price intl=""Canada"" exchange=""0.7"">6.50</price>
    <excerpt>
      <p>It was a dark and stormy night.</p>
      <p>But then all nights in Trenton seem dark and
      stormy to someone who has gone through what
      <emph>I</emph> have.</p>
      <definition-list>
        <term>Trenton</term>
        <definition>misery</definition>
      </definition-list>
    </excerpt>
  </book>
  <my:book xmlns:my=""uri:mynamespace"" style=""leather"" price=""29.50"">
    <my:title>Who's Who in Trenton</my:title>
    <my:author>Robert Bob</my:author>
  </my:book>
</bookstore>";
        }
    }
}
