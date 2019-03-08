using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using StarterTemplate.Services.Contracts;
using StarterTemplate.Repositories.Contracts;
using StarterTemplate.Services;
using System.Threading.Tasks;
using StarterTemplate.Application;

namespace StarterTemplate.Tests.Services
{
    public class ExampleServiceTests
    {
        private readonly IExampleService _exampleService;
        private readonly Mock<IExampleRepository> _exampleRepository;

        public ExampleServiceTests()
        {
            _exampleRepository = new Mock<IExampleRepository>();
            _exampleService = new ExampleService(_exampleRepository.Object);
        }

        /// <summary>
        /// We check if the service when targeting an ExampleModel with Name "teapot" validates that it is a teapot correctly
        /// </summary>
        [Fact]
        public async Task IsItATeaPotAsync_True()
        {
            _exampleRepository.Setup(e => e.GetNameForIdAsync(It.IsAny<int>())).Returns(Task.FromResult("teapot"));

            bool result = await _exampleService.IsItATeaPotAsync(new Models.ExampleModel { Id = 1 });

            Assert.True(result);
        }

        /// <summary>
        /// We check if the service when targeting an ExampleModel with Name other than "teapot" validates that it is not a teapot
        /// </summary>
        [Fact]
        public async Task IsItATeaPotAsync_False()
        {
            _exampleRepository.Setup(e => e.GetNameForIdAsync(It.IsAny<int>())).Returns(Task.FromResult("potato"));

            bool result = await _exampleService.IsItATeaPotAsync(new Models.ExampleModel { Id = 1 });

            Assert.False(result);
        }

        /// <summary>
        /// We check if the service when not finding the needed model, throws a proper NotFound Exception
        /// </summary>
        [Fact]
        public async Task IsItATeaPotAsync_NotFound()
        {
            _exampleRepository.Setup(e => e.GetNameForIdAsync(It.IsAny<int>())).Returns(Task.FromResult(string.Empty));

            await Assert.ThrowsAsync<NotFoundException>(async () => await _exampleService.IsItATeaPotAsync(new Models.ExampleModel { Id = 1 }));            
        }
    }
}