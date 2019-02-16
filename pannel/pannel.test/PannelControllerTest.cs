using Xunit;
using pannel.api.Controllers;
using pannel.api.Models;

namespace pannel.test
{

    public class PannelControllerTest
    {
        [Fact]
        async public void List()
        {

            var controller = new PannelController();

            var result = await controller.list();

            Assert.NotNull(result);
            

        }
    }
}