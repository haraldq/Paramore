﻿#region Licence
/* The MIT License (MIT)
Copyright © 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */
#endregion

using System;
using Machine.Specifications;
using paramore.brighter.restms.server.Adapters.Repositories;
using paramore.brighter.restms.server.Model;
using paramore.brighter.restms.server.Ports.Common;

namespace paramore.commandprocessor.tests.RestMSServer
{
    [Subject("Retrieving a domain via the view model")]
    public class When_retreiving_a_domain
    {
        Establish context = () =>
        {
            var domain = new Domain(
                name: new Name("default"),
                title: new Title("title"),
                profile: new Profile(
                    name: new Name(@"3/Defaults"),
                    href: new Uri(@"href://www.restms.org/spec:3/Defaults")
                    ),
                version: new AggregateVersion(0)
                );


            var feed = new Feed(
                feedType: FeedType.Direct,
                name: new Name("default"),
                title: new Title("Default feed"),
                href: new Uri(@"http://host.com/restms/feed/default")
                );

            var feedRepository = new InMemoryFeedRepository();
            feedRepository.Add(feed);

            domain.AddFeed(feed.Id);

            var domainRepository = new InMemoryDomainRepository();
            domainRepository.Add(domain);
        };


    }
}
