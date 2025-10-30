using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using com.nttdocomo.ui;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Models.IO;
using ImGui.Forms.Resources;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Veldrid;
using Image = SixLabors.ImageSharp.Image;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace DoCoMoPlayer.Components
{
    internal class GameWindow : Component
    {
        private readonly KeyCommand _mainCommand = new(Key.Enter);
        private readonly KeyCommand _upCommand = new(Key.Up);
        private readonly KeyCommand _downCommand = new(Key.Down);
        private readonly KeyCommand _leftCommand = new(Key.Left);
        private readonly KeyCommand _rightCommand = new(Key.Right);
        private readonly KeyCommand _zeroCommand = new(Key.Keypad0);
        private readonly KeyCommand _oneCommand = new(Key.Keypad1);
        private readonly KeyCommand _twoCommand = new(Key.Keypad2);
        private readonly KeyCommand _threeCommand = new(Key.Keypad3);
        private readonly KeyCommand _fourCommand = new(Key.Keypad4);
        private readonly KeyCommand _fiveCommand = new(Key.Keypad5);
        private readonly KeyCommand _sixCommand = new(Key.Keypad6);
        private readonly KeyCommand _sevenCommand = new(Key.Keypad7);
        private readonly KeyCommand _eightCommand = new(Key.Keypad8);
        private readonly KeyCommand _nineCommand = new(Key.Keypad9);
        private readonly KeyCommand _functionCommand = new(Key.Space);

        private readonly object _screenLock = new();

        private Image<Rgba32>? _screen;
        private Bitmap _legacyScreen;
        private readonly PictureBox _pictureBox;

        public GameWindow(Vector2 size)
        {
            _legacyScreen = new Bitmap((int)size.X, (int)size.Y);

            _pictureBox = new PictureBox();

            com.nttdocomo.ui.Canvas.FrameCompleted -= FrameCompleted_Ntt;
            com.nttdocomo.ui.Canvas.FrameCompleted += FrameCompleted_Ntt;

            com.nttdocomostar.ui.Canvas.FrameCompleted -= FrameCompleted_Star;
            com.nttdocomostar.ui.Canvas.FrameCompleted += FrameCompleted_Star;
        }

        private void FrameCompleted_Ntt(object sender, com.nttdocomo.ui.Canvas.FrameCompleteEventArgs e)
        {
            lock (_screenLock)
            {
                ClearRect(_legacyScreen, 0, 0, _legacyScreen.Width, _legacyScreen.Height);
                
                e.Graphics.CopyImage(_legacyScreen, System.Drawing.Point.Empty);

                using var ms = new MemoryStream();
                {
                    _legacyScreen.Save(ms, ImageFormat.Png);
                    ms.Position = 0;

                    _screen = Image.Load<Rgba32>(ms);
                }
            }
        }

        private void FrameCompleted_Star(object sender, com.nttdocomostar.ui.Canvas.FrameCompleteEventArgs e)
        {
            lock (_screenLock)
            {
                ClearRect(_legacyScreen, 0, 0, _legacyScreen.Width, _legacyScreen.Height);

                e.Graphics.CopyImage(_legacyScreen, System.Drawing.Point.Empty);

                using var ms = new MemoryStream();
                {
                    _legacyScreen.Save(ms, ImageFormat.Png);
                    ms.Position = 0;

                    _screen = Image.Load<Rgba32>(ms);
                }
            }
        }

        public override Size GetSize() => Size.Parent;

        public void SetScreenSize(Vector2 screenSize)
        {
            lock (_screenLock)
            {
                _legacyScreen = new Bitmap((int)screenSize.X, (int)screenSize.Y);
            }
        }

        protected override void UpdateInternal(Rectangle contentRect)
        {
            UpdateKeyState();

            lock (_screenLock)
            {
                if (_screen != null)
                    _pictureBox.Image = ImageResource.FromImage(_screen);

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
            if (IsKeyDown(_zeroCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_ZERO);
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
            if (IsKeyDown(_sixCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_SIX);
            if (IsKeyDown(_sevenCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_SEVEN);
            if (IsKeyDown(_eightCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_EIGHT);
            if (IsKeyDown(_nineCommand))
                SendKeyPressedEvent(Display.EVENT_KEY_NINE);
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
            if (IsKeyUp(_zeroCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_ZERO);
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
            if (IsKeyUp(_sixCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_SIX);
            if (IsKeyUp(_sevenCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_SEVEN);
            if (IsKeyUp(_eightCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_EIGHT);
            if (IsKeyUp(_nineCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_NINE);
            if (IsKeyUp(_functionCommand))
                SendKeyReleasedEvent(Display.EVENT_KEY_FUNCTION);
        }

        private void SendKeyPressedEvent(int keyPressed)
        {
            Canvas.receiveEvent(Display.EVENT_KEY_PRESSED, keyPressed);
            com.nttdocomostar.ui.Canvas.receiveEvent(Display.EVENT_KEY_PRESSED, keyPressed);
        }

        private void SendKeyReleasedEvent(int keyPressed)
        {
            Canvas.receiveEvent(Display.EVENT_KEY_RELEASED, keyPressed);
            com.nttdocomostar.ui.Canvas.receiveEvent(Display.EVENT_KEY_RELEASED, keyPressed);
        }

        private unsafe void ClearRect(Bitmap img, int x, int y, int width, int height)
        {
            var bmpData = img.LockBits(new System.Drawing.Rectangle(x, y, width, height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var dataPtr = (uint*)bmpData.Scan0;

            for (var i = 0; i < width * height; i++)
                dataPtr[i] = 0xFF000000;

            img.UnlockBits(bmpData);
        }
    }
}
