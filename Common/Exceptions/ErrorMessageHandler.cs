using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Common.Exceptions
{
    public static class ErrorMessageHandler
    {
        public static HttpResponseMessage CreateErrorMessage(HttpStatusCode errorCode, string phrase, string[] subjects, string[] messages)
        {

            var response = new HttpResponseMessage(errorCode);
            GeneralErrorResponse body = new GeneralErrorResponse();
            body.ErrorCode = ((int)errorCode) + 0.1f;
            body.Details = new List<GeneralErrorDetailsResponse>();

            for (int i = 0; i < subjects.Length; i++)
            {
                body.Details.Add(new GeneralErrorDetailsResponse()
                {
                    Subject = subjects[i],
                    Message = messages[i]
                });
            }

            response.Content = new StringContent(JsonConvert.SerializeObject(body));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.ReasonPhrase = phrase;
            return response;
        }

        public static HttpResponseMessage CreateErrorMessage(HttpStatusCode errorCode, string phrase, string[] subjects, string[] messages, Dictionary<string, string> headers)
        {

            var response = new HttpResponseMessage(errorCode);
            GeneralErrorResponse body = new GeneralErrorResponse();
            body.ErrorCode = ((int)errorCode) + 0.1f;
            body.Details = new List<GeneralErrorDetailsResponse>();

            for (int i = 0; i < subjects.Length; i++)
            {
                body.Details.Add(new GeneralErrorDetailsResponse()
                {
                    Subject = subjects[i],
                    Message = messages[i]
                });
            }

            response.Content = new StringContent(JsonConvert.SerializeObject(body));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (headers.Count() > 0)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    if (header.Key.ToLower() == "retry-after")
                    {
                        //DateTime timeAfter = DateTime.Parse(header.Value);
                        //TimeSpan retryTime = timeAfter - DateTime.Now;
                        response.Headers.RetryAfter = new RetryConditionHeaderValue(DateTime.Parse(header.Value));
                    }
                    else
                    {
                        response.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            response.ReasonPhrase = phrase;
            return response;
        }
    }
}
