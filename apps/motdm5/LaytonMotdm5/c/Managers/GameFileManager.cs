using com.nttdocomo;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Aspects;
using java.lang;

namespace LaytonMotdm5.c.Managers;

[ClassName("c", "o")]
public class GameFileManager : FileManagerBase
{
    [MemberName("e")]
    private static JavaString[][] indexFileNamesByDirectory;
    [MemberName("f")]
    private static int[][] indexFileOffsetsByDirectory;

    [MemberName("g")]
    private JavaString[] loadedFileNames;

    [MemberName("a")]
    public List<object> loadedResources;

    [MemberName("h")]
    private static int unkIntArrayIndex = 0;
    [MemberName("i")]
    private static int[] unkIntArray = new int[] { 260, 190, 200 };
    [MemberName("j")]
    private static int unkInt;
    [MemberName("k")]
    private static int baseDirectoryCount;

    [ConstructorName("o")]
    public GameFileManager()
    {
    }

    [FunctionName("a")]
    public bool LoadFiles(JavaString[] fileNames)
    {
        TryLoadFiles(fileNames);
        return true;
    }

    // Loads files from n base directories into loaded objects for later presenting
    [FunctionName("b")]
    private bool TryLoadFiles(JavaString[] loadFileNames)
    {
        bool allFilesLoaded = true;
        if (loadedResources != null)
            Reset();

        int[] buckets = new int[loadFileNames.Length];
        int[] bucketIndexes = new int[loadFileNames.Length];

        int var5 = -1;
        int var6;
        int fileSize;
        while (true)
        {
        label144:
            var5++;

            if (var5 >= loadFileNames.Length)
                break;

            for (var6 = 0; var6 < indexFileNamesByDirectory.Length; ++var6)
            {
                if (indexFileNamesByDirectory[var6] != null)
                {
                    for (fileSize = 0; fileSize < indexFileNamesByDirectory[var6].Length; ++fileSize)
                    {
                        if (indexFileNamesByDirectory[var6][fileSize].Equals(loadFileNames[var5]))
                        {
                            buckets[var5] = var6;
                            goto label144;
                        }
                    }
                }
            }

            allFilesLoaded = false;
        }

        var5 = 0;

        for (var6 = 0; var6 < indexFileNamesByDirectory.Length; ++var6)
        {
            for (fileSize = 0; fileSize < loadFileNames.Length; ++fileSize)
            {
                if (buckets[fileSize] == var6)
                {
                    bucketIndexes[var5++] = fileSize;
                }
            }
        }

        loadedFileNames = new JavaString[loadFileNames.Length];

        for (var5 = 0; var5 < loadFileNames.Length; ++var5)
        {
            loadedFileNames[var5] = loadFileNames[bucketIndexes[var5]];
        }

        loadedResources = new List<object>();
        object var16 = null;
        byte[] tblData = null;
        int lastBucket = -1;
        baseDirectoryCount = -1;

        for (int var9 = 0; var9 < loadedFileNames.Length; ++var9)
        {
            int lastIndex = -1;
            bool shouldLoadTblData = false;
            java.util.System.Out.Debug("----　読み込むファイルの情報をチェックする ----");

            int currentBucket = buckets[bucketIndexes[var9]];

            for (int var12 = 0; var12 < indexFileNamesByDirectory[currentBucket].Length; ++var12)
            {
                if (indexFileNamesByDirectory[currentBucket][var12].Equals(loadedFileNames[var9]))
                {
                    if (lastBucket != currentBucket)
                        shouldLoadTblData = true;

                    lastBucket = currentBucket;
                    lastIndex = var12;
                    break;
                }
            }

            if (lastIndex == -1)
            {
                java.util.System.Out.Debug("全ｶﾃｺﾞﾘを検索しましたがデータが存在しません　 \n:{0}\nカテゴリの更新か管理者にデータの確認。\nリリースされるときには出てはいけないエラーになります。", loadedFileNames[var9]);
                return false;
            }

            if (shouldLoadTblData)
                tblData = ReadFileData(baseDirectories[lastBucket] + dataFileName);

            if (tblData == null)
            {
                baseDirectoryCount = lastBucket;
                return false;
            }

            if (lastIndex >= indexFileOffsetsByDirectory[lastBucket].Length - 1)
            {
                fileSize = tblData.Length - indexFileOffsetsByDirectory[lastBucket][lastIndex];
            }
            else
            {
                fileSize = indexFileOffsetsByDirectory[lastBucket][lastIndex + 1] - indexFileOffsetsByDirectory[lastBucket][lastIndex];
            }

            byte[] fileData = new byte[fileSize];

            try
            {
                Array.Copy(tblData, indexFileOffsetsByDirectory[lastBucket][lastIndex], fileData, 0, fileSize);
            }
            catch (Exception var13)
            {
                java.util.System.Out.Fatal(var13, "{0}\naddress:{1}\nlen{2}", var13.Message, indexFileOffsetsByDirectory[lastBucket][lastIndex], fileSize);
            }

            if (loadedFileNames[var9].IndexOf(".gif") == -1 && loadedFileNames[var9].IndexOf(".jpg") == -1)
            {
                if (loadedFileNames[var9].IndexOf(".mld") != -1)
                {
                    // If sound, load via MediaManager.GetSound
                    try
                    {
                        MediaSound var20;
                        (var20 = MediaManager.GetSound(fileData)).Use();
                        loadedResources.Add(var20);
                    }
                    catch (Exception var14)
                    {
                        java.util.System.Out.Fatal(var14, "sound {0}", var14.Message);
                        allFilesLoaded = false;
                        baseDirectoryCount = lastBucket;
                        return allFilesLoaded;
                    }
                }
                else if (loadedFileNames[var9].IndexOf(".dat") != -1)
                {
                    // If dat, hold raw data
                    loadedResources.Add(fileData);
                }
            }
            else
            {
                // If image, load via MediaManager.GetImage
                try
                {
                    MediaImage var19;
                    (var19 = MediaManager.GetImage(fileData)).Use();
                    loadedResources.Add(var19.GetImage());
                }
                catch (Exception var15)
                {
                    java.util.System.Out.Fatal(var15, "img {0}", var15.Message);
                    allFilesLoaded = false;
                    baseDirectoryCount = lastBucket;
                    return allFilesLoaded;
                }
            }
        }

        return allFilesLoaded;
    }

    [FunctionName("b")]
    public void Reset()
    {
        if (loadedFileNames != null)
        {
            for (byte b = 0; b < loadedFileNames.Length; b++)
            {
                if (loadedFileNames[b].IndexOf(".gif") != -1 || loadedFileNames[b].IndexOf(".jpg") != -1)
                {
                    // Dispose image resource
                    Image image;
                    (image = GetLoadedImage(loadedFileNames[b])).Dispose();
                    loadedFileNames[b] = "";
                }
                else if (loadedFileNames[b].IndexOf(".mld") != -1)
                {
                    // Dispose sound resource
                    MediaSound mediaSound;
                    (mediaSound = GetLoadedSound(loadedFileNames[b])).Dispose();
                }
                else if (loadedFileNames[b].IndexOf(".dat") != -1)
                {
                    // Ok?
                    GetLoadedData(loadedFileNames[b]);
                }
            }
            loadedFileNames = null;
        }

        if (loadedResources != null)
        {
            loadedResources.Clear();
            loadedResources = null;
        }
    }

    [FunctionName("e")]
    private object GetLoadedObject(JavaString fileName)
    {
        for (byte b = 0; b < loadedFileNames.Length; b++)
        {
            if (loadedFileNames[b] == fileName)
                return loadedResources[b];
        }
        return null;
    }

    [FunctionName("a")]
    public Image GetLoadedImage(JavaString fileName)
    {
        return (Image)GetLoadedObject(fileName);
    }

    [FunctionName("b")]
    public MediaSound GetLoadedSound(JavaString fileName)
    {
        return (MediaSound)GetLoadedObject(fileName);
    }

    [FunctionName("c")]
    public byte[] GetLoadedData(JavaString fileName)
    {
        return (byte[])GetLoadedObject(fileName);
    }

    [FunctionName("a")]
    public static JavaString[] GetBaseDirectories()
    {
        return baseDirectories;
    }

    [FunctionName("d")]
    public static int GetBaseDirectoryCount()
    {
        return baseDirectoryCount;
    }

    [FunctionName("c")]
    public static int InitializeBaseDirectories()
    {
        do
        {
            unkInt = InitializeBaseDirectory();
        } while (unkInt < unkIntArray[unkIntArrayIndex]);

        unkInt = unkIntArray[unkIntArrayIndex];

        GameContext.GetInstance().h1();

        return 1;
    }

    [FunctionName("g")]
    private static int InitializeBaseDirectory()
    {
        if (indexFileNamesByDirectory == null)
        {
            baseDirectoryCount = 0;

            indexFileNamesByDirectory = new JavaString[baseDirectories.Length][];
            indexFileOffsetsByDirectory = new int[baseDirectories.Length][];
        }

        if (baseDirectoryCount < baseDirectories.Length)
        {
            byte[] indexFileData;
            if (baseDirectories[baseDirectoryCount].IndexOf("mov") == 0)
            {
                if ((indexFileData = ReadFileData(baseDirectories[baseDirectoryCount])) != null)
                {
                    baseDirectoryCount++;
                    return baseDirectoryCount * unkIntArray[unkIntArrayIndex] / baseDirectories.Length;
                }
            }
            else
            {
                indexFileData = ReadFileData(baseDirectories[baseDirectoryCount] + indexFileName);
            }

            try
            {
                JavaString indexText = new JavaString(indexFileData);

                int delimiterIndex = indexText.IndexOf('\n') - 1;
                int fileCount = int.Parse(indexText.Substring(0, delimiterIndex));

                indexFileNamesByDirectory[baseDirectoryCount] = new JavaString[fileCount];
                indexFileOffsetsByDirectory[baseDirectoryCount] = new int[fileCount];

                for (byte b = 0; b < fileCount; b++)
                {
                    int skipDelimiterIndex = delimiterIndex + 2;
                    delimiterIndex = indexText.IndexOf(',', skipDelimiterIndex);
                    indexFileNamesByDirectory[baseDirectoryCount][b] = indexText.Substring(skipDelimiterIndex, delimiterIndex);

                    skipDelimiterIndex = delimiterIndex + 1;
                    delimiterIndex = indexText.IndexOf('\n', skipDelimiterIndex) - 1;
                    indexFileOffsetsByDirectory[baseDirectoryCount][b] = int.Parse(indexText.Substring(skipDelimiterIndex, delimiterIndex));
                }

                baseDirectoryCount++;
            }
            catch (Exception throwable)
            {
                return -4;
            }
        }

        return baseDirectoryCount * unkIntArray[unkIntArrayIndex] / baseDirectories.Length;
    }

    [FunctionName("e")]
    public static void DeleteGameData()
    {
        SystemFileManager systemFileManager = new();

        systemFileManager.DeleteFile(baseDirectories[baseDirectoryCount] + ".h");
        systemFileManager.DeleteFile(baseDirectories[baseDirectoryCount] + indexFileName);
        systemFileManager.DeleteFile(baseDirectories[baseDirectoryCount] + dataFileName);
    }

    [FunctionName("d")]
    private static byte[] ReadFileData(JavaString filePath)
    {
        try
        {
            using Stream inputStream = Connector.OpenInputStream(filePath);
            return ReadStreamData(inputStream);
        }
        catch (Exception exception)
        {
            java.util.System.Out.Fatal(exception, "ストレージ読込失敗 sd_storage_name[{0}]データの確認をお願いします {1}", filePath, exception.Message);
        }

        return null;
    }

    [FunctionName("a")]
    private static byte[] ReadStreamData(Stream paramStream)
    {
        var data = new byte[paramStream.Length];
        _ = paramStream.Read(data);

        return data;
    }

    static GameFileManager()
    {
        Initialize();
    }
}
