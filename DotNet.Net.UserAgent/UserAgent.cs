using System.ComponentModel;
using System.Net.Http.Headers;

namespace System.Net
{
    public partial class UserAgent
    {
        internal const string USER_AGENT_HEADER_NAME = "User-Agent";

        public UserAgent(string name, string? version = null, IEnumerable<string>? comments = null, UserAgent? dependentProduct = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Version = version;
            Comments = comments == null ? (new()) : (new(comments));
            DependentProduct = dependentProduct;
        }

        public string Name { get; set; }
        public string? Version { get; set; }
        public UserAgentCommentCollection Comments { get; }
        public UserAgent? DependentProduct { get; set; }

        public override string ToString()
        {
            string userAgent = Name;

            if(!string.IsNullOrWhiteSpace(Version))
                userAgent += "/" + Version;

            if (this is { Comments: not null, Comments: { Count: not 0 } } && Comments.Any(c => !string.IsNullOrWhiteSpace(c)))
                userAgent += $" ({Comments.Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().Join("; ")})"; 

            if (DependentProduct != null)
                userAgent += " " + DependentProduct.ToString();

            return userAgent;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public class UserAgentCommentCollection : List<string>
        {
            internal UserAgentCommentCollection()
            {
            }

            internal UserAgentCommentCollection(IEnumerable<string> comments)
            {
                if (comments == null) return;

                foreach (var comment in comments)
                    Add(comment);
            }

            public new void Add(string comment) => base.Add(_fix(comment));
            public void Add(Uri uri) => base.Add(uri.ToString());

            /// <summary>
            /// Ensures there's a plus sign in front of absolute URLs.
            /// </summary>
            private static string _fix(string comment) => !comment.StartsWith('+') && Uri.IsWellFormedUriString(comment, UriKind.Absolute) ? '+' + comment : comment;
        }
    }
}