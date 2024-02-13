namespace DotDED
{
    [Serializable]
    public class FileFormatException : Exception
    {
        public FileFormatException() { }

        public FileFormatException(string problem) : base("File Format Error (.ded file is corrupt): "+problem) { }
    }
}