using System.Numerics;
using System.Text;
using DocomoCsJavaBridge;
using DoCoMoPlayer.Components;
using DoCoMoPlayer.Models;
using DoCoMoPlayer.Resources;
using ImGui.Forms;
using ImGuiNET;

namespace DoCoMoPlayer.Forms
{
    internal partial class MainForm : Form
    {
        private GameWindow? _gameWindow;

        public MainForm()
        {
            InitializeComponent(GameConfigurationResources.Instance.CurrentLocale);

            Resized += MainForm_Resized;

            _gameSelect.GameSelected += async (s, e) => StartGame(_gameSelect.SelectedGame);
            _languageComboBox.SelectedItemChanged += (_, _) => ChangeGameLanguage(_languageComboBox.SelectedItem.Content);

            SetGameEncoding();
        }

        private void MainForm_Resized(object? sender, EventArgs e)
        {
            _gameWindow?.SetScreenSize(Size);
        }

        private void StartGame(AppContainerData? appContainer)
        {
            if (appContainer == null)
                return;

            if (!AppLauncher.Setup(appContainer))
                return;

            PathProvider.Instance.SetAppSubDirectory(appContainer.AppPath);
            AppInfo.Setup(appContainer.AppName, appContainer.AppData);

            _gameWindow = new GameWindow(AppInfo.GetAppSize());
            Application.Instance.SetSize(AppInfo.GetAppSize());

            Style.SetStyle(ImGuiStyleVar.WindowPadding, Vector2.Zero);

            Content = _gameWindow;

            AppLauncher.Launch();
        }

        private void ChangeGameLanguage(string locale)
        {
            GameConfigurationResources.Instance.ChangeLocale(locale);

            _gameSelect.ChangeLocale(locale);

            SetGameEncoding();
        }

        private void SetGameEncoding()
        {
            string? encodingName = GameConfigurationResources.Instance.GetEncodingName();
            if (!string.IsNullOrEmpty(encodingName))
                DocomoCsJavaBridge.Providers.EncodingProvider.Instance.SetEncoding(Encoding.GetEncoding(encodingName));
        }
    }
}
