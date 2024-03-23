using System.Numerics;
using ImGui.Forms;
using ImGuiNET;
using LaytonMotdm.Components;
using LaytonMotdm.Resources;

namespace LaytonMotdm.Forms
{
    internal partial class MainForm
    {
        private ChapterSelection _chapterSelect;
        private GameWindow _gameWindow;

        private void InitializeComponent()
        {
            Style.SetStyle(ImGuiStyleVar.WindowPadding, Vector2.Zero);

            _gameWindow = new GameWindow();

            Title = LocalizationResources.AppTitle;
            Icon = ImageResources.Icon;

            Size = new Vector2(240, 240);
            Content = _chapterSelect = new ChapterSelection();
        }
    }
}
