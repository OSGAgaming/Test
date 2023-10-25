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
    public class ExpandingCircle : Circle
    {
        public float Velocity;
        public float Damping;
        public float Speed;

        public ExpandingCircle(int radius) : base(radius)
        {
            Damping = 0.08f;
            Speed = 0.01f;
        }

        public void SHMRadiusTo(float radius)
        {
            Velocity += (radius - Radius) * Speed - Velocity * Damping;
            Radius += Velocity;
        }

        public void RecipColorTo(Color target)
        {
            Color t = target;
            Color = new Color(
                (int)(Color.R + (t.R - Color.R) / 16f), 
                (int)(Color.G + (t.G - Color.G) / 16f), 
                (int)(Color.B + (t.B - Color.B) / 16f),
                (int)(Color.A + (t.A - Color.A) / 16f));
        }

    }
}
