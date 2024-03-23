using ImGui.Forms.Localization;

namespace LaytonMotdm.Resources
{
    static class LocalizationResources
    {
        private static readonly Lazy<Localizer> Lazy = new(new Localizer());
        public static ILocalizer Instance => Lazy.Value;

        public static LocalizedString AppTitle => new("Application.Title");
        public static LocalizedString AppTitleWithChapter(int chapter) => new("Application.Title.Chapter", () => chapter);

        public static LocalizedString ChapterSelectionLabel => new("Chapter.Selection.Label");
        public static LocalizedString ChapterSelectionCaption(int chapter) => new("Chapter.Selection.Caption", () => chapter);
    }
}
