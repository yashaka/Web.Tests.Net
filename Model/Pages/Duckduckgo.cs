using System;
using NSelene;
using OpenQA.Selenium;
using Web.Tests.Model.Common;
using static NSelene.Selene;

namespace Web.Tests.Model.Pages
{
    internal class Duckduckgo
    {
        public Results Results => new Results(SS("[data-testid=result]"));

        internal void Open()
        {
            Selene.Open("https://duckduckgo.com/");
        }

        internal void Search(string text)
        {
            S(By.Name("q")).Type(text).PressEnter();
        }
    }
}