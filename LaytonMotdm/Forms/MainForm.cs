using com.nttdocomo;
using DocomoLayton.game;
using DocomoLayton.scene;
using ImGui.Forms;
using LaytonMotdm.Resources;

namespace LaytonMotdm.Forms
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Resized += MainForm_Resized;

            _chapterSelect.ChapterSelected += (s, e) => StartChapter(_chapterSelect.Chapter);
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

            Title = LocalizationResources.AppTitleWithChapter(chapter);
            Content = _gameWindow;
        }
    }
}
