using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Data_Generator;

public class SQLFileManager : IDisposable
{
    #region Dispose Interface
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~SQLFileManager()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion

    readonly string _filePath;

    /// <summary>
    /// If the file already exists, its contents will be erased.
    /// </summary>
    /// <param name="fileName"></param>
    public SQLFileManager(string fileName)
    {
        string path = ConvertToPath(fileName);
        Console.WriteLine(path);

        if (!Path.Exists(path))
        {
            CreateFile(path);
        }
        else
        {
            ClearFile(path);
        }

        _filePath = path;
    }

    void ClearFile(string path)
    {
        System.IO.File.WriteAllText(path, string.Empty);
    }

    public void AppendString(string str)
    {
        using StreamWriter sw = new(_filePath, true);
        sw.WriteLine(str);
    }

    public void AppendStrings(string[] strings)
    {
        using StreamWriter sw = new(_filePath, true);
        foreach(var str in strings)
        {
            sw.WriteLine(str);
        }
    }

    string ConvertToPath(string fileName)
    {
        return AppDomain.CurrentDomain.BaseDirectory + fileName;
    }

    void CreateFile(string path)
    {
        Console.WriteLine($"Creating file {path}.");
        File.Create(path);
    }
}
