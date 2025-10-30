using java.lang;

namespace com.nttdocomo
{
    public class Connector
    {
        public static Stream OpenInputStream(JavaString url)
        {
            return Open(url, false);
        }

        public static Stream OpenOutputStream(JavaString url)
        {
            return Open(url, true);
        }

        private static Stream Open(JavaString url, bool isOutput)
        {
            JavaString protocol = GetProtocol(url);
            switch (protocol)
            {
                case "scratchpad":
                    if (!TryGetIntParameter(url, "pos", out int pos))
                        pos = 0;

                    return ScratchPad.Open(pos, isOutput);

                case "resource":
                    string resourcePath = GetPath(url);
                    return Resources.Open(resourcePath, isOutput);

                // TODO: Use NetworkProtocol from JAM?
                case "http":
                    string urlPath = GetPath(url);
                    return Network.Open(urlPath);

                default:
                    throw new InvalidOperationException($"Unknown url protocol. ({protocol})");
            }
        }

        private static string GetProtocol(JavaString url)
        {
            int protocolIdentifier = url.IndexOf("://");
            if (protocolIdentifier < 0)
                throw new InvalidOperationException($"URL has no valid protocol. ({url})");

            return url[..protocolIdentifier];
        }

        private static string GetPath(JavaString url)
        {
            int protocolIdentifier = url.IndexOf("://");
            if (protocolIdentifier < 0)
                throw new InvalidOperationException($"Not a valid URL. ({url})");

            int parameterIndex = url.IndexOf(';', protocolIdentifier + 3);
            if (parameterIndex < 0)
                parameterIndex = url.Length;

            return url[(protocolIdentifier + 3)..parameterIndex];
        }

        private static bool TryGetIntParameter(string url, string parameterName, out int parameterValue)
        {
            parameterValue = 0;

            if (!TryGetStringParameter(url, parameterName, out string value))
                return false;

            return int.TryParse(value, out parameterValue);
        }

        private static bool TryGetStringParameter(string url, string parameterName, out string parameterValue)
        {
            parameterValue = string.Empty;

            string[] parameters = url.Split(';');

            string? validParameter = parameters.FirstOrDefault(p => p.StartsWith($"{parameterName}="));
            if (validParameter == null)
                return false;

            parameterValue = validParameter[(parameterName.Length + 1)..];
            return true;
        }
    }
}
