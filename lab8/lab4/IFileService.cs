using System.Collections.Generic;

namespace lab4
{
    interface IFileService
    {
        string ElapsedTime { get; }
        List<string> Open(string filename);
        void Save(string filename, string data);
    }
}
