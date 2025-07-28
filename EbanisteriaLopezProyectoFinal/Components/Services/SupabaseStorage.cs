using Microsoft.AspNetCore.Components.Forms;

public class SupabaseStorage
{
    private readonly Supabase.Client _supabaseClient;

    public SupabaseStorage()
    {
        _supabaseClient = new Supabase.Client(
            "https://<tu-url>.supabase.co",
            "<tu-clave-anon>"
        );
    }

    public async Task<List<string>> UploadFiles(List<IBrowserFile> archivos)
    {
        // Tu lógica para subir los archivos
        return new List<string>(); // ejemplo
    }
}
