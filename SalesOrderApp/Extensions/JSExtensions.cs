using Microsoft.JSInterop;

public static class JSExtension
{
    public static async Task LogAsync(this IJSRuntime js, params object?[]? args) => await js.InvokeVoidAsync("console.log", args);
    public static async Task AlertAsync(this IJSRuntime js, params object?[]? args) => await js.InvokeVoidAsync("blazorInterop.displayAlert", args);
}