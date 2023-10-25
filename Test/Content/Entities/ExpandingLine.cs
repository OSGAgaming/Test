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
    public class ExpandingLine : Line
    {
        public float Progress;

        public ExpandingLine(Vector2 p1, Vector2 p2, float lineWidth = 1) : base(p1, p2, lineWidth)
        {
        }

        public void SHMTo(int Point, Vector2 start, Vector2 finish, float increment)
        {
            if (Point == 0)
            {
                p1.X = MathHelper.SmoothStep(start.X, finish.X, Progress);
                p1.Y = MathHelper.SmoothStep(start.Y, finish.Y, Progress);
            }
            else
            {
                p2.X = MathHelper.SmoothStep(start.X, finish.X, Progress);
                p2.Y = MathHelper.SmoothStep(start.Y, finish.Y, Progress);
            }

            if(Progress < 1) Progress += increment;
        }
    }
}
