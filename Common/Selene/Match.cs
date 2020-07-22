
using NSelene;
using NSelene.Conditions;
using OpenQA.Selenium;

namespace Web.Tests.Common.Selene
{
    partial class Match
    {
        public static Condition<IWebDriver> TitleContaining(string text)
            => new TitleContaining(text);
    }

    class TitleContaining : DescribedCondition<IWebDriver>
    {

            private string expected;
            private string actual;

            public TitleContaining(string text)
            {
                this.expected = text;
            }

            public override bool Apply(IWebDriver driver)
            {
                this.actual = driver.Title;
                return this.actual.Contains(this.expected);
            }

            public override string DescribeActual()
            {
                return this.actual;
            }

            public override string DescribeExpected()
            {
                return $"TitleContaining({this.expected})";
            }
    }
}