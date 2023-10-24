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

        public static void Load(ContentManager Content)
        {
            Circle = Content.Load<Texture2D>("Textures/highresCircle");
        }
    }
}
