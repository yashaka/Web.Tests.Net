using System;
using NSelene;
using Web.Tests.Common.Selene;

namespace Web.Tests.Model.Pages
{
    internal class Github
    {
        internal void ShouldBeOn(string pageTitleText)
        {
            Selene.WaitTo(Match.TitleContaining(pageTitleText));
        }
    }
}