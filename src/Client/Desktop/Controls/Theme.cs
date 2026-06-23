using System.Drawing;

namespace UniPlan.Controls
{
    public static class Theme
    {
        public static Color PrimaryColor { get; } = ColorTranslator.FromHtml("#1E3A47");
        public static Color SecondaryColor { get; } = ColorTranslator.FromHtml("#1793B1");

        public static Color BackgroundColor { get; } = ColorTranslator.FromHtml("#F0F4F7");

        public static Color WhiteColor { get; } = ColorTranslator.FromHtml("#FFFFFF");

        public static Color GridHeaderColor { get; } = ColorTranslator.FromHtml("#345463");
    }
}