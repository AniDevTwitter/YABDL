using System;
using System.Net;
using YABDL.Tools.Extensions;
using System.IO;
using YABDL.Models.API.Interfaces;

namespace YABDL.Models.API
{
    public class DanbooruWebResponse<T, U> : IAPIResponse<T>
        where T : IAPIDataObject<U>, new()
    {
        private readonly bool success;
        private readonly string message;
        private readonly T data;

        public DanbooruWebResponse(HttpWebRequest webRequest, U restMetadataProvider)
        {
            using(var response = (HttpWebResponse)webRequest.GetResponse())
            {
                this.data = new T();
                this.success = this.GetDanbooruResponseCode(response.StatusCode, out this.message);
                if (this.success)
                {
                    using(var stream = response.GetResponseStream())
                    {
                        this.data.DeserializeFromXML(stream, restMetadataProvider);
                    }
                }
            }
        }

        private bool GetDanbooruResponseCode(HttpStatusCode code, out string mess)
        {
            switch (code)
            {
                case HttpStatusCode.OK:
                    mess = "200 OK: Request was successful";
                    return true;

                case HttpStatusCode.NoContent:
                    mess = "204 No Content: Request was successful";
                    return true;

                case HttpStatusCode.Forbidden:
                    mess = "403 Forbidden: Access denied";
                    return false;

                case HttpStatusCode.NotFound:
                    mess = "404 Not Found: Not found";
                    return false;

                case (HttpStatusCode)420:
                    mess = "420 Invalid Record: Record could not be saved";
                    return false;

                case (HttpStatusCode)421:
                    // Lol throttled ? What does this mean ?
                    mess = "421 User Throttled: User is throttled, try again later";
                    return false;

                case (HttpStatusCode)422:
                    mess = "422 Locked: The resource is locked and cannot be modified";
                    return false;

                case (HttpStatusCode)423:
                    mess = "423 Already Exists: Resource already exists";
                    return false;

                case (HttpStatusCode)424:
                    mess = "424 Invalid Parameters: The given parameters were invalid";
                    return false;

                case HttpStatusCode.InternalServerError:
                    mess = "500 Internal Server Error: Some unknown error occurred on the server";
                    return  false;

                case HttpStatusCode.ServiceUnavailable:
                    mess = "503 Service Unavailable: Server cannot currently handle the request, try again later";
                    return false;

                default:
                    mess = code.ToString();
                    // Maybe I should throw something here
                    return false;
            }
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public T Data
        {
            get
            {
                return this.data;
            }
        }
    }
}

