using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using com.nttdocomo.ui;
using DocomoCsJavaBridge.Events;
using DocomoLayton.game;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Models.IO;
using ImGui.Forms.Resources;
using Veldrid;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using Point = System.Drawing.Point;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace LaytonMotdm.Components
{
    internal class GameWindow : Component
    {
        private readonly KeyCommand _mainCommand = new(Key.Enter);
        private readonly KeyCommand _upCommand = new(Key.Up);
        private readonly KeyCommand _downCommand = new(Key.Down);
        private readonly KeyCommand _leftCommand = new(Key.Left);
        private readonly KeyCommand _rightCommand = new(Key.Right);
        private readonly KeyCommand _oneCommand = new(Key.Keypad1);
        private readonly KeyCommand _twoCommand = new(Key.Keypad2);
        private readonly KeyCommand _threeCommand = new(Key.Keypad3);
        private readonly KeyCommand _fourCommand = new(Key.Keypad4);
        private readonly KeyCommand _fiveCommand = new(Key.Keypad5);
        private readonly KeyCommand _functionCommand = new(Key.Space);

        private readonly object _screenLock = new();

        private Bitmap _screen;
        private readonly PictureBox _pictureBox;

        private readonly GameContext _gameContext;

        public GameWindow()
        {
            _screen = new Bitmap(240, 240);
            _pictureBox = new PictureBox();

            _gameContext = GameContext.GetInstance();

            _gameContext.FrameCompleted -= FrameCompleted;
            _gameContext.FrameCompleted += FrameCompleted;
        }

        private void FrameCompleted(object sender, FrameCompleteEventArgs e)
        {
            lock (_screenLock)
            {
                ClearRect(_screen, 0, 0, _screen.Width, _screen.Height);

                com.nttdocomo.ui.Graphics g = _gameContext.GetGraphics();
                g.CopyImage(_screen, Point.Empty);
            }
        }

        public override Size GetSize() => Size.Parent;

        public void SetScreenSize(Vector2 screenSize)
        {
            lock (_screenLock)
            {
                _screen = new Bitmap((int)screenSize.X, (int)screenSize.Y);
            }
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            UpdateKeyState();

            lock (_screenLock)
            {
                _pictureBox.Image = ImageResource.FromBitmap(_screen);
                _pictureBox.Update(contentRect);
            }
        }

        private void UpdateKeyState()
        {
            if (IsKeyDown(_mainCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_MAIN);
            if (IsKeyDown(_upCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_UP);
            if (IsKeyDown(_downCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_DOWN);
            if (IsKeyDown(_leftCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_LEFT);
            if (IsKeyDown(_rightCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_RIGHT);
            if (IsKeyDown(_oneCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_ONE);
            if (IsKeyDown(_twoCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_TWO);
            if (IsKeyDown(_threeCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_THREE);
            if (IsKeyDown(_fourCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_FOUR);
            if (IsKeyDown(_fiveCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_FIVE);
            if (IsKeyDown(_functionCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_FUNCTION);

            if (IsKeyUp(_mainCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_MAIN);
            if (IsKeyUp(_upCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_UP);
            if (IsKeyUp(_downCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_DOWN);
            if (IsKeyUp(_leftCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_LEFT);
            if (IsKeyUp(_rightCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_RIGHT);
            if (IsKeyUp(_oneCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_ONE);
            if (IsKeyUp(_twoCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_TWO);
            if (IsKeyUp(_threeCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_THREE);
            if (IsKeyUp(_fourCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_FOUR);
            if (IsKeyUp(_fiveCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_FIVE);
            if (IsKeyUp(_functionCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_FUNCTION);
        }

        private void SendKeyPressedEvent(int keyPressed)
        {
            _gameContext.receiveEvent(Display.EVENT_KEY_PRESSED, keyPressed);
        }

        private void SendKeyReleasedEvent(int keyPressed)
        {
            _gameContext.receiveEvent(Display.EVENT_KEY_RELEASED, keyPressed);
        }

        private unsafe void ClearRect(Bitmap img, int x, int y, int width, int height)
        {
            var bmpData = img.LockBits(new System.Drawing.Rectangle(x, y, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            var dataPtr = (uint*)bmpData.Scan0;

            for (var i = 0; i < width * height; i++)
                dataPtr[i] = 0xFF000000;

            img.UnlockBits(bmpData);
        }
    }
}
