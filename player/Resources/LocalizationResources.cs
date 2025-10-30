using ImGui.Forms.Localization;

namespace DoCoMoPlayer.Resources
{
    static class LocalizationResources
    {
        private static readonly Lazy<Localizer> Lazy = new(new Localizer());
        public static ILocalizer Instance => Lazy.Value;

        public static LocalizedString AppTitle => new("Application.Title");

        public static LocalizedString GameSelectionLabel(string langName) => new("Game.Selection.Label", () => langName);

        public static LocalizedString LanguageSelectionLabel => new("Language.Selection.Label");
        public static LocalizedString LanguageSelectionCaption(string langName) => new($"Language.Selection.{langName}");
    }
}
