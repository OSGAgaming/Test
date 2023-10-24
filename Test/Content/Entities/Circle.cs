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
    public class Circle : Entity, IUpdate, IDraw
    {
        public float Radius;
        public Color Color;

        public Circle(int radius)
        {
            Radius = radius;
            Color = Color.Black;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch sb)
        {
            Vector2 topLeft = Position - new Vector2(Radius);
            sb.Draw(Textures.Circle, new Rectangle((int)topLeft.X, (int)topLeft.Y, (int)Radius*2, (int)Radius*2), Color);
        }
    }
}
