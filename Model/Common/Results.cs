
using NSelene;
using static NSelene.Selene;

namespace Web.Tests.Model.Common
{
    internal class Results
    {
        SeleneCollection list;

        public Results(SeleneCollection list)
        {
            this.list = list;
        }

        public Results ShouldHaveSizeAtLeast(int number)
        {
            list.Should(Have.CountAtLeast(number));
            return this;
        }

        public Results ShouldHaveText(int index, string value)
        {
            list[index].Should(Have.Text(value));
            return this;
        }

        public void FollowLink(int index)
        {
            list[index].Find("[data-testid=result-title-a],[data-test-id=result-link]").Click();
        }
    }
}