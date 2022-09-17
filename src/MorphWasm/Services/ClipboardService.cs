using Microsoft.JSInterop;
using MorphShared.Services;
using MorphWasm.Models;

namespace MorphWasm.Services
{
    public class ClipboardService : IClipboardService
    {
        private IJSRuntime JSInterop { get; set; }

        public ClipboardService(IJSRuntime jsInterop)
        {
            this.JSInterop = jsInterop;
        }

        public async Task Copy(string content)
        {
            var interopResult = await JSInterop.InvokeAsync<JSInteropResult>("morph.wait", content);

            // currently, it seems like JSInterop doesn't wait for the promise to return,
            // making it not possible to meaningfully detect errors from the client script :(
            // this means that interopresult will be null pretty much every time. may need to 
            // file an issue about this.
            if (interopResult != null! && interopResult.IsSuccessful)
            {
                throw new JSException($"Error from JSInterop: {interopResult.Message}");
            }
        }
    }
}
