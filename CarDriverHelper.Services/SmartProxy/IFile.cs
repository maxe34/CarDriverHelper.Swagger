namespace CarDriverHelper.Services.SmartProxy;

    public interface IFile
    {
        FileStream OpenWrite(string path);
    }
