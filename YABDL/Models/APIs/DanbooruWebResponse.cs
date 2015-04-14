using System;
using System.Net;
using System.Collections.Generic;
using YABDL.Tools.Extensions;
using System.IO;
using System.Text;

namespace YABDL.Models.APIs
{
    public class DanbooruWebResponse<T>
    {
        private readonly bool success;
        private readonly string message;
        private readonly T data;

        public DanbooruWebResponse(HttpWebRequest webRequest)
        {
            using(var response = (HttpWebResponse)webRequest.GetResponse())
            {
                this.success = this.GetDanbooruResponseCode(response.StatusCode, out this.message);
                if (this.success)
                {
                    using(var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var dbg = reader.ReadToEnd();
                            Console.WriteLine(dbg);
                            this.data = stream.FromXml<T>(); // TODO : Move this call to something generic with an interface

                        }
                    }
                }
            }
        }

        private bool GetDanbooruResponseCode(HttpStatusCode code, out string message)
        {
            switch (code)
            {
                case HttpStatusCode.OK:
                    message = "200 OK: Request was successful";
                    return true;

                case HttpStatusCode.NoContent:
                    message = "204 No Content: Request was successful";
                    return true;

                case HttpStatusCode.Forbidden:
                    message = "403 Forbidden: Access denied";
                    return false;

                case HttpStatusCode.NotFound:
                    message = "404 Not Found: Not found";
                    return false;

                case (HttpStatusCode)420:
                    message = "420 Invalid Record: Record could not be saved";
                    return false;

                case (HttpStatusCode)421:
                    // Lol throttled ? What does this mean ?
                    message = "421 User Throttled: User is throttled, try again later";
                    return false;

                case (HttpStatusCode)422:
                    message = "422 Locked: The resource is locked and cannot be modified";
                    return false;

                case (HttpStatusCode)423:
                    message = "423 Already Exists: Resource already exists";
                    return false;

                case (HttpStatusCode)424:
                    message = "424 Invalid Parameters: The given parameters were invalid";
                    return false;

                case HttpStatusCode.InternalServerError:
                    message = "500 Internal Server Error: Some unknown error occurred on the server";
                    return  false;

                case HttpStatusCode.ServiceUnavailable:
                    message = "503 Service Unavailable: Server cannot currently handle the request, try again later";
                    return false;

                default:
                    message = code.ToString();
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

