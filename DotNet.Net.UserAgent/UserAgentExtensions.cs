namespace System.Net
{
    namespace Http
    {
        using Headers;

        public static class UserAgentExtensions
        {
            public static void Add(this HttpRequestHeaders headers, UserAgent userAgent)
            {
                if (userAgent == null)
                    throw new ArgumentNullException(nameof(userAgent));

                headers.Add(UserAgent.USER_AGENT_HEADER_NAME, userAgent.ToString());
            }
        }
    }

    namespace WebSockets
    {
        public static class UserAgentExtensions
        {
            public static void SetUserAgent(this ClientWebSocketOptions options, UserAgent userAgent)
            {
                if (userAgent == null)
                    throw new ArgumentNullException(nameof(userAgent));

                options.SetRequestHeader(UserAgent.USER_AGENT_HEADER_NAME, userAgent.ToString());
            }
        }
    }
}