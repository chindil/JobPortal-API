using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stx.Shared.Models.Common;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Stx.Shared.Api.Helpers
{
    public class HttpResponseHelper
    {

        public enum ResponseType
        {
            CandidateNotFound,
            CandidateInvalid,
            ContentTypeInvalid,
            ProvidedValueInvalid,
            RecordMayNotExists,
			RecordNotFound,
        }

    static GetActionResultInner cls = new GetActionResultInner();
        public static IActionResult GetResponse(HttpStatusCode statusCode, string message)
        {
            return cls.GetActionResult(statusCode, string.IsNullOrWhiteSpace(message) ? "Internal Server Error." : message);
        }

        public static IActionResult GetResponse(ResponseType  responseType)
        {
            return cls.GetActionResult(responseType);
        }

        public class GetActionResultInner : ControllerBase
        {
            internal IActionResult GetActionResult(HttpStatusCode statusCode, string message)
            {
                return StatusCode((int)statusCode,
                    (
                        new ErrorDetails()
                        {
                            StatusCode = (int)statusCode,
                            Message = message
                        })
                    );
            }
            internal IActionResult GetActionResult(ResponseType responseType)
            {
                var resp = GetResponseErrorDetails(responseType);
                return StatusCode((int)resp.StatusCode, resp);
            }

            private ErrorDetails GetResponseErrorDetails(ResponseType responseType)
            {
                switch (responseType)
                {
                    case ResponseType.CandidateNotFound:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.NotFound, Message = "The candidate entity may not exists." };
                    case ResponseType.CandidateInvalid:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Invalid candidate entry." };
                    case ResponseType.ContentTypeInvalid:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Invalid content type." };
                    case ResponseType.ProvidedValueInvalid:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.BadRequest, Message = "The provided value is invalid." };
                    case ResponseType.RecordMayNotExists:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.NotFound, Message = "The record may not exists." };
                    case ResponseType.RecordNotFound:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.NotFound, Message = "No valid job entries found." };
                    default:
                        return new ErrorDetails { StatusCode = (int)HttpStatusCode.InternalServerError, Message = "Internal server error." };
                }
            }
        }


    }


}
