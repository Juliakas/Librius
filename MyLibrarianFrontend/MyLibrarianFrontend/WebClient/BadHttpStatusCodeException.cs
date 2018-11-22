using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyLibrarianFrontend.WebClient
{
    internal class BadHttpStatusCodeException : Exception
    {
        public HttpResponseMessage ResponseMessage { get; }
        public HttpStatusCode StatusCode { get; }

        public BadHttpStatusCodeException() : base()
        {
        }

        public BadHttpStatusCodeException(string message) : base(message)
        {
        }

        public BadHttpStatusCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BadHttpStatusCodeException(string message, HttpResponseMessage httpResponseMessage) : base(message)
        {
            StatusCode = httpResponseMessage.StatusCode;
            ResponseMessage = httpResponseMessage;
        }

        public BadHttpStatusCodeException(string message, HttpResponseMessage httpResponseMessage, Exception innerException) : base(message, innerException)
        {
            new BadHttpStatusCodeException(message, httpResponseMessage);
        }

        protected BadHttpStatusCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}