using Cosmos.HAL;

namespace ScreenStuff {
    public static class Screen {

        public static void Init() {
            var screen = new VGAScreen();

            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            //screen.Clear(0);

            SetPixel(100, 100, 255);
            ReDraw(screen);
            DrawFilledRectangle(0, 0, 1320, 200, 10);
            DrawFilledRectangle(0, 175, 320, 25, 60);
            
        }

        private static byte[] SBuffer = new byte[64000];
        private static void ReDraw(VGAScreen screen) {
            // VScreen.Clear(0);

            int c = 0;

            for (int y = 0; y < 200; y++) {
                for (int x = 0; x < 320; x++) {
                    uint cl = screen.GetPixel320x200x8((uint)x, (uint)y);
                    if (cl != (uint)SBuffer[c]) {
                        screen.SetPixel320x200x8((uint)x, (uint)y, SBuffer[c]);
                    }
                    c++;
                }
            }
            for (int i = 0; i < 64000; i++) {
                SBuffer[i] = 0;
            }
        }

        public static void SetPixel(int x, int y, int color) {
            SBuffer[(y * 320) + x] = (byte)color;
        }

        
        /*codeproject.com*/
        public static void DrawFilledRectangle(uint x0, uint y0, int Width, int Height, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint h = 0; h < Height; h++)
                {
                    SetPixel((int)(x0 + i), (int)(y0 + h), color);
                }
            }
        }
    }
}
