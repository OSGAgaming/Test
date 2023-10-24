using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Content.Entities;

namespace Test
{
    public static class Textures
    {
        public static Texture2D Circle;
        public static Texture2D Pixel;

        public static void Load(ContentManager Content)
        {
            Circle = Content.Load<Texture2D>("Textures/highresCircle");
            Pixel = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }
    }
}
