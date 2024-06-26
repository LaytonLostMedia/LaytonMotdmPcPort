using com.nttdocomo.device;
using com.nttdocomo.fs;
using DocomoCsJavaBridge;
using DocomoCsJavaBridge.Aspects;
using File = com.nttdocomo.fs.File;

namespace DocomoLayton.game.Managers;

[ClassName("c", "i")]
public class SystemFileManager
{
    [MemberName("a")]
    private StorageDevice device = StorageDevice.GetInstance("/ext0");
    [MemberName("b")]
    private DoJaAccessToken accessToken = DoJaStorageService.GetAccessToken(4, 8);
    [MemberName("c")]
    private Folder lastTouchedFolder;

    [FunctionName("a")]
    public File OpenFile(JavaString filePath)
    {
        try
        {
            lastTouchedFolder = device.GetFolder(accessToken);
            return lastTouchedFolder.GetFile(filePath);
        }
        catch (Exception exception)
        {
            DocomoCsJavaBridge.System.Out.Fatal(exception, "{0} 読み込み失敗 {1}", filePath, exception.Message);
            return null;
        }
    }

    [FunctionName("b")]
    public void DeleteFile(JavaString filePath)
    {
        try
        {
            lastTouchedFolder = device.GetFolder(accessToken);
            lastTouchedFolder.GetFile(filePath).Delete();
        }
        catch { }
    }
}
