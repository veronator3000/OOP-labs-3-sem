using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IDirectory
{
    IList<IDirectory> Directories { get; }
    IList<IFile> Files { get; }
    string Name { get; }
    IDirectory? FindDirectoryByPath(string directoryPath);
    WorkResult CreateDirectory(string name);
    WorkResult Delete();
    WorkResult CreateFile(string name);
    IFile? FindFileByName(string fileName);
    WorkResult SetAnotherWorkingPlace(string path);
    WorkResult InitDirectory(string root);
}