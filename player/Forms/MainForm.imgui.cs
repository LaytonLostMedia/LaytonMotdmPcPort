using System.Numerics;
using DoCoMoPlayer.Components;
using DoCoMoPlayer.Resources;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;

namespace DoCoMoPlayer.Forms
{
    internal partial class MainForm
    {
        private Label _languageLabel;
        private DropDownBox<string> _languageComboBox;

        private GameSelection _gameSelect;

        private StackLayout _languageLayout;
        private StackLayout _mainLayout;

        private void InitializeComponent(string locale)
        {
            _gameSelect = new GameSelection(locale);

            _languageComboBox = new DropDownBox<string>();
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
                    _gameSelect
                }
            };

            Title = LocalizationResources.AppTitle;
            Icon = ImageResources.Icon;

            Size = new Vector2(300, 300);
            Content = _mainLayout;

            InitializeLanguageComboBox(_languageComboBox, locale);
        }

        private void InitializeLanguageComboBox(DropDownBox<string> languageComboBox, string locale)
        {
            IList<string> configuredLocales = GameConfigurationResources.Instance.GetLocales();

            foreach (string configuredLocale in configuredLocales)
            {
                string languageName = GameConfigurationResources.Instance.GetLanguageName(configuredLocale);
                languageComboBox.Items.Add(new ComboBoxItem<string>(configuredLocale, LocalizationResources.LanguageSelectionCaption(languageName)));
            }

            languageComboBox.SelectedItem = languageComboBox.Items.FirstOrDefault(x => x.Content == locale);
        }
    }
}
