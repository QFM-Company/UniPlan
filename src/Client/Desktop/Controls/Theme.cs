using System.Drawing;

namespace UniPlan.Controls
{
    public static class Theme
    {
        public static Color PrimaryColor { get; } = ColorTranslator.FromHtml("#1E3A47");
        public static Color SecondaryColor { get; } = ColorTranslator.FromHtml("#1793B1");
        public static Color SecondaryHoverColor { get; } = ColorTranslator.FromHtml("#1EB1D4");
        public static Color SecondaryClickColor { get; } = ColorTranslator.FromHtml("#137A94");

        public static Color BackgroundColor { get; } = ColorTranslator.FromHtml("#F0F4F7");
        public static Color GridHeaderColor { get; } = ColorTranslator.FromHtml("#345463");

        public static Color WhiteColor { get; } = ColorTranslator.FromHtml("#FFFFFF");
        public static Color TextPrimaryColor { get; } = ColorTranslator.FromHtml("#2C3E50");
        public static Color TextSecondaryColor { get; } = ColorTranslator.FromHtml("#7F8C8D");
    }
}               