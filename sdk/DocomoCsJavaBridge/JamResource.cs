using DocomoCsJavaBridge.Providers;
using System.Numerics;

namespace DocomoCsJavaBridge
{
    public class JamResource
    {
        public static JamData Load(Stream jamStream)
        {
            var reader = new StreamReader(jamStream, EncodingProvider.Instance.GetEncoding(), leaveOpen: false);

            var jamData = new JamData();

            var jamLine = reader.ReadLine();
            while (jamLine != null)
            {
                string[] lineParts = jamLine.Split(" = ");
                if (lineParts.Length >= 2)
                {
                    switch (lineParts[0])
                    {
                        case "AppName":
                            jamData.AppName = lineParts[1];
                            break;

                        case "AppVer":
                            jamData.AppVersion = lineParts[1];
                            break;

                        case "PackageURL":
                            jamData.PackageUrl = lineParts[1];
                            break;

                        case "AppSize":
                            jamData.AppSize = int.Parse(lineParts[1]);
                            break;

                        case "SPsize":
                            jamData.SpSize = lineParts[1].Split(',').Select(int.Parse).ToArray();
                            break;

                        case "AppClass":
                            jamData.AppClass = lineParts[1];
                            break;

                        case "AppParam":
                            jamData.AppParam = lineParts[1].Split(' ').ToArray();
                            break;

                        case "LastModified":
                            jamData.LastModified = lineParts[1];
                            break;

                        case "UseNetwork":
                            jamData.NetworkProtocol = lineParts[1];
                            break;

                        case "TargetDevice":
                            jamData.TargetDevice = lineParts[1];
                            break;

                        case "DrawArea":
                            string[] sizeParts = lineParts[1].Split("x");
                            if (sizeParts.Length >= 2)
                                jamData.DrawArea = new Vector2(int.Parse(sizeParts[0]), int.Parse(sizeParts[1]));

                            break;

                        case "CPName":
                            jamData.CompanyName = lineParts[1];
                            break;
                    }
                }

                jamLine = reader.ReadLine();
            }

            return jamData;
        }
    }

    public class JamData
    {
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string PackageUrl { get; set; }
        public int AppSize { get; set; }
        public int[] SpSize { get; set; }
        public string AppClass { get; set; }
        public string[] AppParam { get; set; }
        public string LastModified { get; set; }
        public string NetworkProtocol { get; set; }
        public string TargetDevice { get; set; }
        public Vector2 DrawArea { get; set; }
        public string CompanyName { get; set; }
    }
}
