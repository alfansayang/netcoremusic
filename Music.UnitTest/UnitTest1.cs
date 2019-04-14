using Microsoft.AspNetCore.Mvc;
using Music.Web.Controllers;
using Music.Web.Repository;
using System;
using Xunit;

namespace Music.UnitTest
{
    public class UnitTest1
    {
        ArtistController _controller;
        IArtistRepository _artistRepository;

        public UnitTest1(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
            _controller = new ArtistController(_artistRepository);             
        }

        [Fact]
        public void GetAllArtist()
        {
            //act
            var result = _controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}
