using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Data.Models;
using MoviesWebAPI.Data.Requests.Users;
using MoviesWebAPI.Data.Responses.Users;
using MoviesWebAPI.Services.Users;
using MoviesWebAPI.Utils;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _service { get; set; }

        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// This retreives all users and their data from database
        /// </summary>
        /// <response code="200">All users were successfully send</response>
        /// <response code="300">Users list couldn't be send</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                AllUsersResponse response = await _service.GetAllUsers();

                return Ok(response);
            }
            catch (Exception ex)
            {
                AllUsersResponse error = new AllUsersResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_ALL_USERS_REQUEST_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets a user's data by its ID
        /// </summary>
        /// <param name="userID"></param>
        /// <response code="200">User with given ID was successfully found.It retreives its data</response>
        /// <response code="300">ID is missing from header</response>
        /// <response code="301">User with given ID doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet]
        [Route("get-user-by-id")]
        public async Task<IActionResult> GetUserByID([FromHeader] int? userID)
        {
            if (userID == null)
            {
                UserResponse response = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "userID"
                };

                return BadRequest(response);
            }

            try
            {
                UserResponse response = await _service.GetUserByID(userID);

                if (response.User != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                UserResponse error = new UserResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.GET_USER_BY_ID_RESPONSE_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This gets a user(s) data by its name
        /// </summary>
        /// <param name="userName"></param>
        /// <response code="200">User with given name was successfully found.It retreives its data</response>
        /// <response code="300">Username is missing from header</response>
        /// <response code="301">User with given name doesn't exist in database</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpGet, Route("get-user-by-name")]
        public async Task<IActionResult> GetUserByName([FromHeader] string? userName)
        {
            if (userName == null)
            {
                UserResponse noHeaderResponse = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "userName"
                };

                return BadRequest(noHeaderResponse);
            }

            try
            {

                AllUsersResponse allUsersResponse = await _service.GetUserByName(userName);

                return Ok(allUsersResponse);

            }
            catch (Exception ex)
            {
                UserResponse error = new UserResponse { Code = 400, Message = APIErrorCodes.GET_USER_BY_NAME_RESPONSE_EXCEPTION_MESSAGE + ex.Message };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This adds a new user to database
        /// </summary>
        /// <remarks>
        /// Minimum Body request:
        ///
        ///     
        ///     {
        ///        "userName": "string",
        ///        "password": "string",
        ///        "email": "string"
        ///     }
        ///     
        /// For full body request see in example schema
        /// </remarks>
        /// <param name="userRequest"></param>
        /// <response code="200">User was successfully registered</response>
        /// <response code="300">Username is missing from body</response>
        /// <response code="301">Password is missing from body</response>
        /// <response code="302">Email is missing from body</response>
        /// <response code="303">The password entered is already in use</response>
        /// <response code="304">The email entered is already in use</response>
        /// <response code="305">User registration was unsuccessful</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpPost, Route("add-new-user")]
        public async Task<IActionResult> AddNewUser([FromBody] UserRequest userRequest)
        {

            //username mezo ures,visszateritem a hibat
            if (String.IsNullOrEmpty(userRequest.UserName))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Username is missing from body!"
                };

                return BadRequest(userResponse);
            }

            //jelszo mezo ures,visszateritem a hibat
            if (String.IsNullOrEmpty(userRequest.Password))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Password is missing from body!"
                };

                return BadRequest(userResponse);
            }

            //email mezo ures => visszateritem a hibat
            if (String.IsNullOrEmpty(userRequest.Email))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 302,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Email is missing from body!"
                };

                return BadRequest(userResponse);
            }


            if (String.IsNullOrEmpty(userRequest.FirstName))
            {
                userRequest.FirstName = null;
            }

            if (String.IsNullOrEmpty(userRequest.LastName))
            {
                userRequest.LastName = null;
            }

            if (String.IsNullOrEmpty(userRequest.Gender))
            {
                userRequest.Gender = null;
            }

            try
            {
                UserResponse userResponse = await _service.AddNewUser(userRequest);

                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                UserResponse error = new UserResponse { Code = 400, Message = APIErrorCodes.ADD_NEW_USER_EXCEPTION_MESSAGE + ex.Message };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates user profile data
        /// </summary>
        /// <remarks>
        /// Minimum Body request:
        ///
        ///     
        ///     {
        ///        "userName": "string",
        ///        "email": "string"
        ///     }
        ///     
        /// For full body request see in example schema (without password!!)
        /// </remarks>
        /// <param name="userId"></param>
        /// <param name="userRequest"></param>
        /// <response code="200">Updates user profile data in database and returns it</response>
        /// <response code="300">UserID wasn't given in the request's header</response>
        /// <response code="301">Username wasn't given in the request's body</response>
        /// <response code="302">Email wasn't given in the request's body</response>
        /// <response code="303">Update method gave us an null, meaning the backend couldn't update user's profile</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpPut, Route("update-user-profile")]
        public async Task<IActionResult> UpdateUserProfile([FromHeader] int? userId, [FromBody] UserRequest userRequest)
        {
            if (userId == null)
            {
                UserResponse response = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.HEADER_MISSING_MESSAGE + "userID"
                };

                return BadRequest(response);
            }

            if (String.IsNullOrEmpty(userRequest.UserName))
            {
                UserResponse response = new UserResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Username is missing from body"
                };

                return BadRequest(response);
            }

            if (String.IsNullOrEmpty(userRequest.Email))
            {
                UserResponse response = new UserResponse
                {
                    Code = 302,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Email is missing from body"
                };

                return BadRequest(response);
            }

            if (String.IsNullOrEmpty(userRequest.FirstName))
            {
                userRequest.FirstName = null;
            }

            if (String.IsNullOrEmpty(userRequest.LastName))
            {
                userRequest.LastName = null;
            }

            if (String.IsNullOrEmpty(userRequest.Gender))
            {
                userRequest.Gender = null;
            }

            try
            {
                UserResponse userResponse = await _service.UpdateUserProfile(userId, userRequest);

                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                UserResponse error = new UserResponse { Code = 400, Message = APIErrorCodes.ADD_NEW_USER_EXCEPTION_MESSAGE + ex.Message };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Updates user's current password with the new password.
        /// </summary>
        /// <remarks>
        /// Body request:
        ///
        ///     
        ///     {
        ///        "userName": "string",
        ///        "password": "string",
        ///        "email": "string"
        ///     }
        ///     
        /// Ignore the example schema, use the above request for password update
        /// </remarks>
        /// <param name="userRequest"></param>
        /// <response code="200">User's password was successfully changed</response>
        /// <response code="300">Username is missing from body</response>
        /// <response code="301">Email is missing from body</response>
        /// <response code="302">Password is missing from body</response>
        /// <response code="303">User with given username and email doesn't exist</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpPut,Route("update-user-password")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UserRequest userRequest)
        {
            if (String.IsNullOrEmpty(userRequest.UserName))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Username is missing from body"
                };

                return BadRequest(userResponse);
            }

            if (String.IsNullOrEmpty(userRequest.Email))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Email is missing from body"
                };

                return BadRequest(userResponse);
            }

            if (String.IsNullOrEmpty(userRequest.Password))
            {
                UserResponse userResponse = new UserResponse
                {
                    Code = 302,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Password is missing from body"
                };

                return BadRequest(userResponse);
            }

            try
            {
                UserResponse response = await _service.UpdateUserPassword(userRequest);

                return Ok(response);

            }catch (Exception ex)
            {
                UserResponse error = new UserResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.UPDATE_USER_PASSWORD_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }

        /// <summary>
        /// This is the login feature for the website
        /// </summary>
        /// <remarks>
        /// Body request:
        ///
        ///     
        ///     {
        ///        "userName": "string",
        ///        "password": "string"
        ///     }
        ///     
        /// Ignore the example schema, use the above request for login
        /// </remarks>
        /// <param name="userRequest"></param>
        /// <response code="200">Login succes</response>
        /// <response code="300">Username is missing from body</response>
        /// <response code="301">Password is missing from body</response>
        /// <response code="302">Your username or password is incorrect</response>
        /// <response code="400">Some error happened at backend level and returned an exception</response>
        /// <returns></returns>
        [HttpPost,Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserRequest userRequest)
        {
            if (String.IsNullOrEmpty(userRequest.UserName))
            {
                UserResponse error = new UserResponse
                {
                    Code = 300,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Username is missing from body"
                };

                return BadRequest(error);
            }

            if (String.IsNullOrEmpty(userRequest.Password))
            {
                UserResponse error = new UserResponse
                {
                    Code = 301,
                    Message = APIErrorCodes.BODY_MISSING_MESSAGE + "Password is missing from body"
                };

                return BadRequest(error);
            }

            try
            {
                UserResponse response = await _service.LoginUser(userRequest);

                return Ok(response);

            }catch (Exception ex)
            {
                UserResponse error = new UserResponse
                {
                    Code = 400,
                    Message = APIErrorCodes.LOGIN_EXCEPTION_MESSAGE + ex.Message
                };

                return BadRequest(error);
            }
        }
    }
}
