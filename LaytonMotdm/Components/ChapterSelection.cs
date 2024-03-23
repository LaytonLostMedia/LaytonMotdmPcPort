using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using ImGui.Forms.Models.IO;
using LaytonMotdm.Resources;
using Veldrid;

namespace LaytonMotdm.Components
{
    internal class ChapterSelection : Component
    {
        private Label _selectLabel;

        private Button _chapter1Btn;
        private Button _chapter2Btn;
        private Button _chapter3Btn;

        private StackLayout _chapterLayout;

        public int Chapter { get; private set; }

        public event EventHandler ChapterSelected;

        public ChapterSelection()
        {
            _selectLabel = new Label { Text = LocalizationResources.ChapterSelectionLabel };

            _chapterLayout = new StackLayout
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

            AddChapterButtons(_chapterLayout);
        }

        public override Size GetSize()
        {
            return Size.Parent;
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            _chapterLayout.Update(contentRect);
        }

        private void AddChapterButtons(StackLayout chapterLayout)
        {
            foreach (string resourcePath in Directory.GetDirectories("resources", "*", SearchOption.TopDirectoryOnly))
            {
                string resourceDirectory = Path.GetRelativePath("resources", resourcePath);
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

            ChapterSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
