using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Specialized;
namespace CH.Common
{
    public class RequestWrapperParameterBinding:HttpParameterBinding
    {
        public RequestWrapperParameterBinding(HttpParameterDescriptor pd)
            : base(pd)
        {

        }
        private struct AsyncVoid { };
        public override System.Threading.Tasks.Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var request = System.Web.HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            SetValue(actionContext, new RequestWrapper(request));
            // now, we can return a completed task with no result
            TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
            tcs.SetResult(default(AsyncVoid));
            return tcs.Task;
        }
    }
}
