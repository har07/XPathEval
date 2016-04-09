# XPathEval
Online XPath tester that supports higher version of XPath. Currently supports XPath 3.0 and XQuery 3.0 via Saxon-HE 9.7 and XPath 1.0 via .NET XPath engine.

This is a little tools that enables people, like me, to play around with features available in XPath version higher than 1.0. I've been a regular user of [freeformatter](http://www.freeformatter.com/xpath-tester.html) in the past and then [xpathtester](http://www.xpathtester.com/xpath), for quick-testing and sharing short XPath demo, mainly [around StackOverflow](http://stackoverflow.com/search?q=user:2998271+[xpath]). The tools works very well for testing XPath 1.0, but their support for XPath 2.0 and above seems limited. 

Considering the above, and that a great XML processor like Saxon has a free version available, I decided to roll out my own XPath tester, which currently named XPathEval (just like [eval.in](https://eval.in/) that I've been using too).

Contributing
-------------

Contribution of any form from the community are very welcomed (especially for the GUI/front-end part). This project is created using Visual Studio 2015 community, and all dependencies are restorable from NuGet, so I hope it would be trivial to build the project from anybody's machine given VS2015 is installed.

The `.sln` includes a Test poject containing serveral unit tests that you can run. However, only a few of the main project codes are covered by the unit test at the moment.

