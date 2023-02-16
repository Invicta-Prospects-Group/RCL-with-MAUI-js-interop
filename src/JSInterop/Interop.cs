using Microsoft.JSInterop;

namespace jsInterop.JSInterop;

public class Interop : IAsyncDisposable
{

    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public Interop(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() =>
            jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/jsInterop.RazorClassLibrary/MyJS.js").AsTask());
    }

    // Create methods to call the functions from the JS file

    public async Task SetDisplayModeByElementIdAsync(string elementId, string mode)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setDisplayModeByElementId", elementId, mode);
    }

    public async Task ScrollToBottomAsync(string elementName)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollToBottom", elementName);
    }

    public async Task<string> ReadClipboardTextAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("readClipboardText");
    }

    public async Task WriteClipboardTextAsync(string text)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("writeClipboardText", text);
    }

    public async Task ShowAlertAsync(string text)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showAlert", text);
    }


    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}