using Moq;
using WebApp1.MVC.Controllers;
using WebApp1.MVC.DataAccess;

namespace WebApp1.Tests.ControllersTests
{
    public class MusicControllerTests
    {
        private readonly MusicController _target;
        private readonly Mock<WebAppDbContext> _context;

        public MusicControllerTests()
        {
            _context = new Mock<WebAppDbContext>();
            _target = new MusicController(_context.Object);
        }

        [Fact]
        public void IndexReturnsValidData()
        {
            // Act
            var actual = _target.Index();
            
            // Assert
            Assert.NotNull(actual);
        }
    }
}