using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace xunit.bug.tests
{
    public class ValuesTests
    {
        [Fact]
        public async Task Get_WhenCalled_ReturnsHttpSuccess()
        {
            var server = new TestServer(new WebHostBuilder()
                                        .UseContentRoot(Path.Combine("..", "..", "..", "..", "xunit.bug"))
                                        .UseStartup<Startup>());
            var client = server.CreateClient();

            var response = await client.GetAsync("/api/values");

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
