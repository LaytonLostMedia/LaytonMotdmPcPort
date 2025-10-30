using com.nttdocomostar.fs;

namespace com.nttdocomo.device;

public class StorageDevice
{
    private readonly string _device;

    public static StorageDevice GetInstance(string device) => new(device);

    public StorageDevice(string device)
    {
        _device = device;
    }

    public Folder GetFolder(AccessToken token) => new(token);
    public bool IsAccessible() => true;
    public bool IsRemovable() => false;
    public bool IsWritable() => true;
    public bool IsReadable() => true;
}

