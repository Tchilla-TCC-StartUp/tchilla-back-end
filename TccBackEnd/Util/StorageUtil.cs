namespace TccBackEnd.Util;

public class StorageUtil
{
    public static string UploadFile(IFormFile file, string folderName)
    {
        // Caminho absoluto da pasta wwwroot/assets
        string wwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", folderName);

        if (!Directory.Exists(wwwRoot))
        {
            Directory.CreateDirectory(wwwRoot);
        }

        // Gera um nome único para o arquivo
        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(wwwRoot, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        // Retorna a URL relativa que pode ser usada no front
        return $"assets/{folderName}/{uniqueFileName}";
    }
}
