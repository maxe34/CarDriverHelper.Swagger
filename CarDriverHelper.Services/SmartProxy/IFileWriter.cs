namespace CarDriverHelper.Services.SmartProxy;

    public interface IFileWriter
    {
        void WriteTwiceToSameFile(string outputFile, string message);
    }
