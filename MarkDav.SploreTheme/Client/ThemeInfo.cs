using Oqtane.Models;
using Oqtane.Themes;

namespace MarkDav.SploreTheme
{
    public class ThemeInfo : ITheme
    {
        public Theme Theme => new Theme
        {
            Name = "SploreTheme",
            Version = "1.0.0",
            PackageName = "MarkDav.SploreTheme"
        };

    }
}
