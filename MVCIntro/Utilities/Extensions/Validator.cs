using MVCIntro.Utilities.Enums;

namespace MVCIntro.Utilities.Extensions;

public static class Validator
{
    public static bool ValidateType(this IFormFile file, string type)
    {
        if (file.ContentType.Contains(type))
        {
            return true;

        }
        return false;
    }
    public static bool ValidateSize(this IFormFile formFile, FileSizes fileSize, int size)
    {
        switch (fileSize)
        {
            case FileSizes.KB:
                return formFile.Length > size * 1024;
            case FileSizes.MB:
                return formFile.Length > size * 1024 * 1024;
            case FileSizes.GB:
                return formFile.Length > size * 1024 * 1024 * 1024;
        }

        return false;
    }
    public async static Task<string> CreateFile (this IFormFile formFile, params string[] roots)
        {
            string fileName = String.Concat(Guid.NewGuid().ToString(),formFile.FileName);

            string path= string.Empty;
             
             for(int i = 0; i < roots.Length; i++)
            {
                path=Path.Combine(path,roots[i]);
            }

              path=Path.Combine(path,fileName);
             
             using(FileStream fileStream = new(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            };

          
                return fileName;
           
        }
    public static void DeleteFile(this string fileName, params string[] roots)
    {
        string path = string.Empty;
        for (int i = 0; i < roots.Length; i++)
        {
            path = Path.Combine(path, roots[i]);
        }
        path = Path.Combine(path, fileName);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
