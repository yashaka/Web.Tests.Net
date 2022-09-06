using System;
using NSelene;
using OpenQA.Selenium;
using Web.Tests.Model.Common;
using static NSelene.Selene;

namespace Web.Tests.Model.Pages
{
    internal class Ecosia 
    {
        public Results Results => new Results(SS("[data-test-id=organic-result]"));

        internal void Open()
        {
            Selene.Open("https://www.ecosia.org/");
        }

        internal void Search(string text)
        {
            S(By.Name("q")).Type(text).PressEnter();
        }
    }
}