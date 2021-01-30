using System.Threading.Tasks;
using LikeFeatureProject.Api.Host;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http.Headers;
using LikeFeatureProject.Api.Host.Models.Like.Response;

namespace LikeFeatureProject.Api.IntegrationTest
{
    public class GeneralPageTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GeneralPageTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public static IEnumerable<object[]> ValidGetUrls => new List<object[]>
        {
            new object[] {"/v1/like?articleId=5", "application/json"}
        };

        public static IEnumerable<object[]> ValidPostUrls => new List<object[]>
        {
            new object[] {"/v1/like?articleId=5", "application/json"}
        };

        [Theory]
        [MemberData(nameof(ValidGetUrls))]
        public async Task ValidGetUrlsReturnSuccess(string path, string mediaType)
        {
            var expected = new MediaTypeHeaderValue(mediaType);

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(path);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expected.MediaType, response.Content.Headers.ContentType.MediaType);
            Assert.NotNull(responseString);
        }

        [Theory]
        [MemberData(nameof(ValidPostUrls))]
        public async Task ValidPostUrlsReturnSuccess(string path, string mediaType)
        {
            var expected = new MediaTypeHeaderValue(mediaType);

            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(path, null);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(expected.MediaType, response.Content.Headers.ContentType.MediaType);
            Assert.NotNull(responseString);
        }

    }
}
