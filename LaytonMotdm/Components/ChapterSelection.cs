using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using LaytonMotdm.Resources;
using Veldrid;

namespace LaytonMotdm.Components
{
    internal class ChapterSelection : Component
    {
        private Label _selectLabel;
        private StackLayout _chapterLayout;

        public int Chapter { get; private set; }

        public event EventHandler ChapterSelected;

        public ChapterSelection(string locale)
        {
            _selectLabel = new Label { Text = LocalizationResources.ChapterSelectionLabel };

            _chapterLayout = CreateChapterLayout(locale);
        }

        public override Size GetSize()
        {
            return Size.Parent;
        }

        public void ChangeLocale(string locale)
        {
            _chapterLayout = CreateChapterLayout(locale);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            _chapterLayout.Update(contentRect);
        }

        private StackLayout CreateChapterLayout(string locale)
        {
            var chapterLayout = new StackLayout
            {
                Size = Size.Content,
                Alignment = Alignment.Vertical,
                VerticalAlignment = VerticalAlignment.Center,
                ItemSpacing = 4,
                Items =
                {
                    new StackItem(_selectLabel) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center }
                }
            };

            AddChapterButtons(chapterLayout, locale);

            return chapterLayout;
        }

        private void AddChapterButtons(StackLayout chapterLayout, string locale)
        {
            string baseDir = Path.Combine("resources", locale);
            if(!Directory.Exists(baseDir))
                return;

            foreach (string resourcePath in Directory.GetDirectories(baseDir, "*", SearchOption.TopDirectoryOnly))
            {
                string resourceDirectory = Path.GetRelativePath(baseDir, resourcePath);
                if (!resourceDirectory.StartsWith("deathmirror"))
                    continue;

                string chapterPart = resourceDirectory[11..];
                int chapter = string.IsNullOrEmpty(chapterPart) ? 1 : int.Parse(chapterPart);

                var chapterBtn = new Button { Text = LocalizationResources.ChapterSelectionCaption(chapter), Width = 100 };
                var item = new StackItem(chapterBtn) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };

                chapterBtn.Clicked += (s, e) => SelectChapter(chapter);

                chapterLayout.Items.Add(item);
            }
        }

        private void SelectChapter(int chapter)
        {
            Chapter = chapter;

            ChapterSelected.Invoke(this, EventArgs.Empty);
        }
    }
}
