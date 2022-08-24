using Xunit;
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MoviesWebAPI.Data.Models;
using MoviesWebAPI.Services.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Services.Genres;
using System.Collections.Generic;
using MoviesWebAPI.Services.Movies;
using MoviesWebAPI.Data.Responses.Movies;
using MoviesWebAPI.Services.Users;
using MoviesWebAPI.Data.Responses.Users;
using MoviesWebAPI.Controllers;
using MoviesWebAPI.Repositories.Movies;

namespace MoviesWEBAPI_UnitTests
{
    public class MockDatas
    {
        public static List<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies
                {
                    Mov_Id = 1,
                    Title = "Batman",
                    ReleaseDate = DateTime.Now,
                    RunTime = 120,
                    Rating = 8,
                    NumberOfRatings = 520,
                },
                new Movies {
                    Mov_Id = 5,
                    Title = "Pokember",
                    ReleaseDate= DateTime.Now,
                    Rating = 6,
                    RunTime = 990,
                    NumberOfRatings = 230,
                    },
                new Movies {
                    Mov_Id = 12,
                    Title = "Titanic",
                    ReleaseDate= DateTime.Now,
                    Rating = 10,
                    RunTime = 69,
                    NumberOfRatings = 150,
                    },
            };
        }

        public static List<Users> GetUsers()
        {
            return new List<Users>
            {
                new Users
                {
                    Id = 134,
                    UserName = "Palko",
                    Password = "12345",
                    Email = "Palko@gmail.com"
                },
                new Users
                {
                    Id = 29,
                    UserName = "Bence",
                    Password = "54321",
                    Email = "Bence@gmail.com"
                },
            };
        }
    }

    public class TestService
    {
        [Fact]
        public async Task GetMoviesByTitle_SuccessShouldReturn200()
        {
            //Arrange
            IEnumerable<Movies> dummyMovieList = MockDatas.GetMovies();
            var movieService = new Mock<IMovieRepository>();
            movieService.Setup(_ => _.GetMoviesByTitle("Batman")).ReturnsAsync(dummyMovieList);
            var sut = new MovieService(movieService.Object);

            //Act
            var result = await sut.GetMoviesByTitle("Batman");

            //Assert
            result.Code.Should().Be(200);
        }

        [Fact]
        //1. name of method which we test, 2. scenario we are testing, 3. expected behaviour
        public async Task GetAllMovies_GetAllWithSuccess_Returns200Async()
        {
            //Arrange
            Movies movie1 = new Movies { Mov_Id = 1, Title = "Batman1", ReleaseDate = DateTime.Now, RunTime = 1000, Rating = 500, NumberOfRatings = 250 };
            Movies movie2 = new Movies { Mov_Id = 2, Title = "Pokember2", ReleaseDate = DateTime.Now, RunTime = 360, Rating = 800, NumberOfRatings = 320 };
            IEnumerable<Movies> dummyMovieList = new List<Movies>();

            //AllMoviesResponse dummyAllMovieResponse = new AllMoviesResponse();
            /*dummyAllMovieResponse = new AllMoviesResponse
            {
                Code = 200,
                Message = "Success Returning All Movies from Service",
                MovieList = dummyMovieList,
            };
            */

            var movieService = new Mock<IMovieRepository>();
            movieService.Setup(_ => _.GetAllMovies()).ReturnsAsync(dummyMovieList);
            var sut = new MovieService(movieService.Object);

            //Act
            var result = (AllMoviesResponse) await sut.GetAllMovies();
             
            //Assert
            result.Code.Should().Be(200);
        }

        [Fact]
        public async Task GetAllMovies_Failure_Returns300Async()
        {
            //Arrange
            AllMoviesResponse dummyMovieResponse = new AllMoviesResponse
            {
                Code = 300,
                Message = "Couldnt get movies from database",
                MovieList = null
            };

            IEnumerable<Movies>? dummyMovieList = null;
            

            var movieService = new Mock<IMovieRepository>();
            movieService.Setup(_ => _.GetAllMovies()).ReturnsAsync(dummyMovieList);
            var sut = new MovieService(movieService.Object);

            //Act
            var result = await sut.GetAllMovies();

            //Assert
            result.Code.Should().Be(300);
        }
    }

    public class TestController
    {
        [Fact]
        public async Task GetAllUsers_SuccessShouldReturn200()
        {
            //Arrange 
            AllUsersResponse dummyResponse = new AllUsersResponse();
            dummyResponse.UserList = MockDatas.GetUsers();

            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetAllUsers()).ReturnsAsync(dummyResponse);
            var sut = new UsersController(userService.Object);

            //Act 
            var result = (OkObjectResult) await sut.GetAllUsers();

            //Assert 
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllUsers_FailureShouldReturn400()
        {
            //Arrange 
            AllUsersResponse dummyResponse = new AllUsersResponse();
            dummyResponse.UserList = null;

            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetAllUsers()).ThrowsAsync(new Exception());
            var sut = new UsersController(userService.Object);

            //Act 
            var result = (BadRequestObjectResult)await sut.GetAllUsers();

            //Assert 
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetUserByID_SuccessShouldReturn200()
        {
            //Arrange
            UserResponse dummyResponse = new UserResponse();
            dummyResponse = new UserResponse()
            {
                Code = 200,
                Message = "SuccessInReturningOneID",
                User = new Users
                {
                    Id = 134,
                    UserName = "Palko",
                    Password = "12345",
                    Email = "Palko@gmail.com"
                }
            };

            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserByID(134)).ReturnsAsync(dummyResponse);
            var sut = new UsersController(userService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetUserByID(134);

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetUserByID_FailedBecauseNotFindUserReturn400()
        {
            //Arrange
            UserResponse dummyResponse = new UserResponse();
            dummyResponse = new UserResponse()
            {
                Code = 300,
                Message = "NoSuccessInReturningOneID",
                User = new Users
                {
                    Id = 134,
                    UserName = "Palko",
                    Password = "12345",
                    Email = "Palko@gmail.com"
                }
            };

            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserByID(134)).ReturnsAsync(dummyResponse);
            var sut = new UsersController(userService.Object);

            //Act
            var result = (BadRequestObjectResult) await sut.GetUserByID(137);

            //Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task GetUserByID_FailedBecauseEmptyHeaderReturn300()
        {
            //Arrange
            UserResponse dummyResponse = new UserResponse();
            dummyResponse = new UserResponse()
            {
                Code = 300,
                Message = "NoSuccessInReturningOneID",
                User = new Users
                {
                    Id = 134,
                    UserName = "Palko",
                    Password = "12345",
                    Email = "Palko@gmail.com"
                }
            };

            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserByID(null)).ReturnsAsync(dummyResponse);
            var sut = new UsersController(userService.Object);

            //Act
            var result = (BadRequestObjectResult)await sut.GetUserByID(null);
            var userResponseResult = result.Value as UserResponse;

            //Assert
            userResponseResult.Code.Should().Be(300);
        }
    }
  
    /*
    public class MoviesServiceTest
    {
        [Fact]
        public async Task GetAllMovies_ShouldReturn200Status()
        {
            //Arrange
            var moviesService = new Mock<IMovieService>();
            moviesService.Setup(_ => _.GetAllMovies()).ReturnsAsync(MoviesMockData.GetMovies());

            var sut = new MovieService(moviesService.Object);

            
        }
        // Act
        var result = (OkObjectResult) await sut.getAllAsync();

        // Assert
        result.StatusCode.Should().Be(200);
    }
    */
    
    

}
