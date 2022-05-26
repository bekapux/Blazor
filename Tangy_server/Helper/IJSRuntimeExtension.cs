using Microsoft.JSInterop;

namespace Tangy_server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "success", Message);
        }
        public static async ValueTask ToastrError(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "error", Message);
        }
        public static async ValueTask Log(this IJSRuntime jSRuntime, object Message)
        {
            await jSRuntime.InvokeVoidAsync("console.log", Message);
        }

        public static async ValueTask ShowModal(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("ShowDeleteConfirmationModal");
        }
        public static async ValueTask HideModal(this IJSRuntime jSRuntime)
        {
            await jSRuntime.InvokeVoidAsync("HideDeleteConfirmationModal");
        }
    }
}
