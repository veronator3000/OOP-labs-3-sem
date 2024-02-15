using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Output;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.LocalFileSystem;

public class FileLocal : IFile
{
    public FileLocal(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public WorkResult MoveContent(string destinationDirectory)
    {
        destinationDirectory =
            destinationDirectory ?? throw new ArgumentNullException(nameof(destinationDirectory));
        try
        {
            string fileName = Path.GetFileName(Name);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);
            System.IO.File.Move(Name, destinationFilePath);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedMoveFile("file: " + Name + "cannot be moved");
        }
    }

    public WorkResult RenameFile(string newName)
    {
        try
        {
            int lastSlashIndex = Name.LastIndexOf(Path.DirectorySeparatorChar);
            string directoryPath = Name.Substring(0, lastSlashIndex + 1);
            string newFullFilePath = Path.Combine(directoryPath, newName);
            if (System.IO.File.Exists(newFullFilePath))
            {
                return new WorkResult.ExistingFile("file already exist");
            }

            System.IO.File.Move(Name,  Path.Combine(directoryPath, newName));
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedRenameFile("file: " + Name + "cannot be renamed");
        }
    }

    public WorkResult CopyFile(string destinationDirectory)
    {
        try
        {
            string fileName = Path.GetFileName(Name);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);
            System.IO.File.Copy(Name, destinationFilePath);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedCopyFile("file: " + Name + "cannot be copied");
        }
    }

    public WorkResult ReadContent(MajorDisplay display)
    {
        display = display ?? throw new ArgumentNullException(nameof(display));
        try
        {
            string content = System.IO.File.ReadAllText(Name);
            display.Output(content);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedReadContent("file: " + Name + "cannot be read");
        }
    }

    public WorkResult WriteContent(string text)
    {
        try
        {
            System.IO.File.WriteAllText(Name, text);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedWriteContent("unable to write data");
        }
    }

    public WorkResult Delete()
    {
        try
        {
            System.IO.File.Delete(Name);
            return new WorkResult.SuccessfulDataProcessing();
        }
        catch (IOException)
        {
            return new WorkResult.FailedDeleteFile("unable to delete file");
        }
    }
}