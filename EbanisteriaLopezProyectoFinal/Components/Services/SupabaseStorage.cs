using Microsoft.AspNetCore.Components.Forms;

public static class SupabaseStorage
{
    public static async Task<List<string>> UploadFiles(List<IBrowserFile> files)
    {
        var urls = new List<string>();
        foreach (var file in files)
        {
            
            urls.Add($"https://tusupabase.com/{file.Name}");
        }
        return urls;
    }
}