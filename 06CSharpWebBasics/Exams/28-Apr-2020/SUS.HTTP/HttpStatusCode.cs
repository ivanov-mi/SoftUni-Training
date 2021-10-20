namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        Ok = 200,
        MoverPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        NotFound = 404,
        ServerError = 500,
    }
}
