using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;

namespace Test.Content.Entities
{
    public class Line : Entity, IUpdate, IDraw
    {
        public Vector2 p1;
        public Vector2 p2;

        public float lineWidth;

        Color Color;
        public Line(Vector2 p1, Vector2 p2, float lineWidth = 1)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.lineWidth = lineWidth;
            Color = Color.White;
        }

        public void Update() { }

        public void Draw(SpriteBatch sb)
        {
            Vector2 between = p2 - p1;
            float length = between.Length();
            float rotation = (float)Math.Atan2(between.Y, between.X);
            sb.Draw(Textures.Pixel, p1, null, Color, rotation, new Vector2(0f, 0.5f), new Vector2(length, lineWidth), SpriteEffects.None, 0);
        }
    }
}
