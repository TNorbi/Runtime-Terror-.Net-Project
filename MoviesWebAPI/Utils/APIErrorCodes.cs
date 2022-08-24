namespace MoviesWebAPI.Utils
{
    public class APIErrorCodes
    {
        public static readonly string HEADER_MISSING_MESSAGE = "The following header value is missing: ";
        public static readonly string BODY_MISSING_MESSAGE = "The request was unsuccessful due to the following missing value in body: ";
        public static readonly string GET_ALL_USERS_REQUEST_EXCEPTION_MESSAGE = "GET_ALL_USERS request was unsuccessful, with the following error message: ";
        public static readonly string GET_ALL_USERS_NULL_MESSAGE = "Get all users was unsuccessfull. Please try again!";
        public static readonly string GET_USER_BY_ID_RESPONSE_EXCEPTION_MESSAGE = "GET_USER_BY_ID request was unsuccessful, with the following error message: ";
        public static readonly string GET_USER_BY_ID_NOT_FOUND_MESSAGE = "User with given ID doesn't exist in database.";
        public static readonly string GET_USER_BY_NAME_NOT_FOUND_MESSAGE = "User with given name doesn't exist in database.";
        public static readonly string GET_USER_BY_NAME_RESPONSE_EXCEPTION_MESSAGE = "GET_USER_BY_NAME request was unsuccessful, with the following error message: ";
        public static readonly string ADD_NEW_USER_PASSWORD_EXISTS_MESSAGE = "The password entered is already in use.";
        public static readonly string ADD_NEW_USER_EMAIL_EXISTS_MESSAGE = "The email entered is already in use.";
        public static readonly string ADD_NEW_USER_NULL_MESSAGE = "User registration was unsuccessful. Please try again!";
        public static readonly string ADD_NEW_USER_EXCEPTION_MESSAGE = "ADD_NEW_USER request was unsuccessful, with the following error message: ";
        public static readonly string UPDATE_USER_NULL_MESSAGE = "User data update was unsuccessfull. Please try again!";
        public static readonly string UPDATE_USER_EXCEPTION_MESSAGE = "UPDATE_USER_PROFILE request was unsuccessful, with the following error message: ";
        public static readonly string UPDATE_USER_PASSWORD_NULL_MESSAGE = "User with given username and email doesn't exist. Please check your username or email and try again.";
        public static readonly string UPDATE_USER_PASSWORD_EXCEPTION_MESSAGE = "UPDATE_USER_PASSWORD request was unsuccessful, with the following error message: ";
        public static readonly string LOGIN_NULL_MESSAGE = "Login Failed: Your username or password is incorrect";
        public static readonly string LOGIN_EXCEPTION_MESSAGE = "LOGIN_USER request was unsuccessful, with the following error message: ";
        public static readonly string GET_ALL_MOVIES_NULL_MESSAGE = "Get all movies was unsuccessfull. Please try again!";
        public static readonly string GET_ALL_MOVIES_EXCEPTION_MESSAGE = "GET_ALL_MOVIES request was unsuccessful, with the following error message: ";
        public static readonly string GET_MOVIE_BY_ID_NULL_MESSAGE = "Movie with given ID doesn't exist in database";
        public static readonly string GET_MOVIE_BY_ID_EXCEPTION_MESSAGE = "GET_MOVIE_BY_ID request was unsuccessful, with the following error message: ";
        public static readonly string GET_MOVIES_BY_TITLE_NULL_MESSAGE = "Get movies with given title was unsuccessfull. Please try again!";
        public static readonly string GET_MOVIES_BY_TITLE_EXCEPTION_MESSAGE = "GET_MOVIES_BY_TITLE request was unsuccessful, with the following error message: ";
        public static readonly string GET_ALL_RATINGS_NULL_MESSAGE = "Get all ratings was unsuccessfull. Please try again!";
        public static readonly string GET_ALL_RATINGS_EXCEPTION_MESSAGE = "GET_ALL_RATINGS request was unsuccessful, with the following error message: ";
        public static readonly string ADD_NEW_RATING_NULL_MESSAGE = "Add new rating was unsuccessfull. Please try again!";
        public static readonly string ADD_NEW_RATING_EXCEPTION_MESSAGE = "ADD_NEW_RATING request was unsuccessful, with the following error message: ";
        public static readonly string INVALID_RATING_VALUE_RANGE_MESSAGE = "Given rating value is not in [1,10] range!";
        public static readonly string GET_RATINGS_BY_USERID_EXCEPTION_MESSAGE = "GET_RATINGS_BY_USERID request was unsuccessful, with the following error message: ";
        public static readonly string GET_RATINGS_BY_MOVIEID_EXCEPTION_MESSAGE = "GET_RATINGS_BY_MOVIEID request was unsuccessful, with the following error message: ";
        public static readonly string GET_RATING_BY_MOVIEID_AND_USERID_NOT_FOUND_MESSAGE = "The given movie wasn't rated by the given user!";
        public static readonly string UPDATE_RATING_NULL_MESSAGE = "Update rating was unsuccessfull. Please try again!";
        public static readonly string UPDATE_RATING_EXCEPTION_MESSAGE = "UPDATE_RATING request was unsuccessful, with the following error message: ";
        public static readonly string DELETE_RATING_NULL_MESSAGE = "Delete rating was unsuccessfull. Please try again!";
        public static readonly string DELETE_RATING_EXCEPTION_MESSAGE = "DELETE_RATING request was unsuccessful, with the following error message: ";
        public static readonly string GET_ALL_USERS_WATCHLIST_NULL_MESSAGE = "Get all user's watchlist was unsuccessfull. Please try again!";
        public static readonly string GET_ALL_USERS_WATCHLIST_EXCEPTION_MESSAGE = "GET_ALL_USERS_WATCHLIST request was unsuccessful, with the following error message: ";
        public static readonly string GET_USER_WATCHLIST_BY_USERID_NULL_MESSAGE = "Get user's watchlist with given userID was unsuccessfull. Please try again!";
        public static readonly string GET_USER_WATCHLIST_BY_USERID_EXCEPTION_MESSAGE = "GET_USER_WATCHLIST_BY_ID request was unsuccessful, with the following error message: ";
        public static readonly string GET_USER_WATCHLIST_BY_USERNAME_NULL_MESSAGE = "Get user's watchlist with given username was unsuccessfull. Please try again!";
        public static readonly string GET_USER_WATCHLIST_BY_USERNAME_EXCEPTION_MESSAGE = "GET_USER_WATCHLIST_BY_USERNAME request was unsuccessful, with the following error message: ";
        public static readonly string ADD_MOVIE_TO_WATCHLIST_NULL_MESSAGE = "Couldn't add movie to user's watchlist.Please try again!";
        public static readonly string ADD_MOVIE_TO_WATCHLIST_EXCEPTION_MESSAGE = "ADD_MOVIE_TO_WATCHLIST request was unsuccessful, with the following error message: ";
        public static readonly string DELETE_MOVIE_FROM_WATCHLIST_NULL_MESSAGE = "Couldn't delete movie from user's watchlist.Please try again!";
        public static readonly string DELETE_MOVIE_FROM_WATCHLIST_EXCEPTION_MESSAGE = "DELETE_MOVIE_FROM_WATCHLIST request was unsuccessful, with the following error message: ";
    }
}
