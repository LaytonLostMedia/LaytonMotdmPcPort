using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using LaytonMotdm.Components;
using LaytonMotdm.Resources;

namespace LaytonMotdm.Forms
{
    internal partial class MainForm
    {
        private Label _languageLabel;
        private ComboBox<string> _languageComboBox;

        private ChapterSelection _chapterSelect;

        private StackLayout _languageLayout;
        private StackLayout _mainLayout;

        private void InitializeComponent(string locale)
        {
            _chapterSelect = new ChapterSelection(locale);

            _languageComboBox = new ComboBox<string>();
            _languageLabel = new Label { Text = LocalizationResources.LanguageSelectionLabel };
            _languageLayout = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                Size = ImGui.Forms.Models.Size.Content,
                ItemSpacing = 4,
                Items =
                {
                    _languageLabel,
                    _languageComboBox
                }
            };

            _mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 4,
                Items =
                {
                    new StackItem(_languageLayout) { HorizontalAlignment = HorizontalAlignment.Right, Size = ImGui.Forms.Models.Size.WidthAlign },
                    _chapterSelect
                }
            };

            Title = LocalizationResources.AppTitle;
            Icon = ImageResources.Icon;

            Size = new Vector2(240, 240);
            Content = _mainLayout;

            InitializeLanguageComboBox(_languageComboBox, locale);
        }

        private void InitializeLanguageComboBox(ComboBox<string> languageComboBox, string locale)
        {
            IList<string> locs = GameConfigurationResources.Instance.GetLocales();

            foreach (string loc in locs)
            {
                string languageName = GameConfigurationResources.Instance.GetLanguageName(loc);
                languageComboBox.Items.Add(new ComboBoxItem<string>(loc, LocalizationResources.LanguageSelectionCaption(languageName)));
            }

            languageComboBox.SelectedItem = languageComboBox.Items.FirstOrDefault(x => x.Content == locale);
        }
    }
}
