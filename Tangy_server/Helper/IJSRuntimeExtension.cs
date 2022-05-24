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
  }
}
