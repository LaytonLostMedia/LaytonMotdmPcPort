using com.nttdocomo;
using DocomoLayton.game;
using DocomoLayton.scene;
using ImGui.Forms;
using ImGuiNET;
using LaytonMotdm.Resources;
using System.Numerics;
using System.Text;
using LaytonMotdm.Components;
using EncodingProvider = DocomoCsJavaBridge.Providers.EncodingProvider;

namespace LaytonMotdm.Forms
{
    internal partial class MainForm : Form
    {
        private GameWindow _gameWindow;

        public MainForm()
        {
            InitializeComponent(GameConfigurationResources.Instance.CurrentLocale);

            Resized += MainForm_Resized;

            _chapterSelect.ChapterSelected += (s, e) => StartChapter(_chapterSelect.Chapter);
            _languageComboBox.SelectedItemChanged += (s, e) => ChangeGameLanguage(_languageComboBox.SelectedItem.Content);
            
            SetGameLanguage();

            _gameWindow = new GameWindow();
        }

        private void MainForm_Resized(object? sender, EventArgs e)
        {
            _gameWindow.SetScreenSize(Size);
        }

        private void StartChapter(int chapter)
        {
            StartupScene.Chapter = chapter;
            AppInfo.Setup("deathmirror" + (chapter == 1 ? "" : $"{chapter}"));

            Task.Run(() => GameContext.GetInstance().Start());

            Style.SetStyle(ImGuiStyleVar.WindowPadding, Vector2.Zero);

            Title = LocalizationResources.AppTitleWithChapter(chapter);
            Content = _gameWindow;
        }

        private void ChangeGameLanguage(string locale)
        {
            GameConfigurationResources.Instance.ChangeLocale(locale);
            _chapterSelect.ChangeLocale(locale);

            SetGameLanguage();
        }

        private void SetGameLanguage()
        {
            // Set game paths
            string? scratchPadFolder = GameConfigurationResources.Instance.GetScratchPadFolder();
            if (!string.IsNullOrEmpty(scratchPadFolder))
                PathProvider.Instance.SetScratchPadSubDirectory(scratchPadFolder);

            string? resourceFolder = GameConfigurationResources.Instance.GetResourceFolder();
            if (!string.IsNullOrEmpty(resourceFolder))
                PathProvider.Instance.SetResourceSubDirectory(resourceFolder);

            // Set game encoding
            string? encodingName = GameConfigurationResources.Instance.GetEncodingName();
            if (!string.IsNullOrEmpty(encodingName))
                EncodingProvider.Instance.SetEncoding(Encoding.GetEncoding(encodingName));
        }
    }
}
