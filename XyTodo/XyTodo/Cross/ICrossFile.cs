namespace XyTodo.Cross
{
    public interface ICrossFile
    {
        string GetLocalFilePath( string filename );
        string GetLocalImagePath( string imgname);
    }
}
