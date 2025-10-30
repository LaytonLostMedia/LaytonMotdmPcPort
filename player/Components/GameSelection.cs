using DoCoMoPlayer.Models;
using DoCoMoPlayer.Resources;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using Veldrid;

namespace DoCoMoPlayer.Components
{
    internal class GameSelection : Component
    {
        private readonly AppProvider _appProvider;

        private Label _selectLabel;
        private StackLayout _gameLayout;

        public AppContainerData? SelectedGame { get; private set; }

        public event EventHandler GameSelected;

        public GameSelection(string locale)
        {
            _appProvider = AppProvider.Create();

            string languageName = GameConfigurationResources.Instance.GetLanguageName(locale);
            _selectLabel = new Label { Text = LocalizationResources.GameSelectionLabel(languageName) };

            _gameLayout = CreateGameLayout(locale);
        }

        public override Size GetSize()
        {
            return Size.Parent;
        }

        public void ChangeLocale(string locale)
        {
            SelectedGame = null;

            string languageName = GameConfigurationResources.Instance.GetLanguageName(locale);
            _selectLabel.Text = LocalizationResources.GameSelectionLabel(languageName);

            _gameLayout = CreateGameLayout(locale);
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            _gameLayout.Update(contentRect);
        }

        private StackLayout CreateGameLayout(string locale)
        {
            var gameLayout = new StackLayout
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

            AddGameButtons(gameLayout, locale);

            return gameLayout;
        }

        private void AddGameButtons(StackLayout gameLayout, string locale)
        {
            foreach (AppContainerData appContainer in _appProvider.GetApps(locale))
            {
                var gameBtn = new Button { Text = (string)appContainer.AppData.AppName, Width = 120 };
                var item = new StackItem(gameBtn) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };

                gameBtn.Clicked += (s, e) => SelectGame(appContainer);

                gameLayout.Items.Add(item);
            }
        }

        private void SelectGame(AppContainerData appContainer)
        {
            SelectedGame = appContainer;

            GameSelected.Invoke(this, EventArgs.Empty);
        }
    }
}
