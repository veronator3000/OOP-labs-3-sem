using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.LocalFileSystem;

public class DirectoryLocal : IDirectory
{
    public DirectoryLocal(string name)
    {
        Directories = new List<IDirectory>();
        Files = new List<IFile>();
        Name = name;
        InitDirectory(name);
    }

    public DirectoryLocal(IList<IDirectory> directories, IList<IFile> files, string name)
    {
        Directories = directories;
        Files = files;
        Name = name;
        InitDirectory(name);
    }

    public IList<IDirectory> Directories { get; }
    public IList<IFile> Files { get; }
    public string Name { get; private set; }

    public WorkResult InitDirectory(string root)
    {
        try
        {
            root = root ?? throw new ArgumentNullException(nameof(root));
            foreach (string file in System.IO.Directory.GetFiles(root))
            {
                Files.Add(new FileLocal(file));
            }

            foreach (string dir in System.IO.Directory.GetDirectories(root))
            {
                Directories.Add(new DirectoryLocal(dir));
            }

            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedDataProcessing("error");
        }
    }

    public IDirectory? FindDirectoryByPath(string directoryPath)
    {
        return Name.Equals(directoryPath, StringComparison.OrdinalIgnoreCase)
            ? this : Directories.Select(subDirectory => subDirectory.FindDirectoryByPath(directoryPath)).FirstOrDefault(result => result != null);
    }

    public WorkResult CreateDirectory(string name)
    {
        try
        {
            string newDirPath = Path.Combine(Name, name);
            if (System.IO.Directory.Exists(newDirPath))
            {
                return new WorkResult.FailedDataProcessing("error");
            }

            DirectoryInfo newDir = System.IO.Directory.CreateDirectory(Path.Combine(Name, name));
            Directories.Add(new DirectoryLocal(newDir.FullName));
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedCreateFile("unable to create directory " + Name);
        }
    }

    public WorkResult Delete()
    {
        try
        {
            System.IO.Directory.Delete(Name, true);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedDeleteFile("unable to delete directory");
        }
    }

    public WorkResult CreateFile(string name)
    {
        try
        {
            string filePath = Path.Combine(Name, name);
            if (System.IO.File.Exists(filePath))
            {
                return new WorkResult.ExistingFile("file already exist");
            }

            System.IO.File.Create(filePath).Close();
            Files.Add(new FileLocal(filePath));
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedCreateFile("unable to create file");
        }
    }

    public IFile? FindFileByName(string fileName)
    {
        foreach (IFile file in Files)
        {
            if (file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
            {
                return file;
            }
        }

        return Directories.Select(subDirectory => subDirectory.FindFileByName(fileName)).FirstOrDefault(result => result != null);
    }

    public WorkResult SetAnotherWorkingPlace(string path)
    {
        Name = path;
        Directories.Clear();
        Files.Clear();
        return InitDirectory(path);
    }
}