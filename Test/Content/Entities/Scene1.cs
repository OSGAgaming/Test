using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Content.Entities;

namespace Test.Core
{
    public class Scene1 : World
    {
        public List<Line> lines;
        public List<ExpandingCircle> circles;

        public int slide;
        public int currentSlideCooldown;
        public int cooldown = 60;
        public override void LoadEntities()
        {
            lines = new List<Line>();
            circles = new List<ExpandingCircle>
            {
                AddEntity(new ExpandingCircle(0)) as ExpandingCircle,
                AddEntity(new ExpandingCircle(0)) as ExpandingCircle
            };

            circles[0].Position = new Vector2(300,130);
            circles[1].Position = new Vector2(190, 100);

            lines.Add(AddEntity(new Line(circles[0].Position, circles[0].Position)) as Line);
            lines.Add(AddEntity(new Line(circles[1].Position, circles[1].Position)) as Line);
        }

        public override void OnUpdate()
        {
            if (currentSlideCooldown > 0) currentSlideCooldown--;

            if (currentSlideCooldown == 0 &&
                Keyboard.GetState().IsKeyDown(Keys.D))
            {
                slide++;
                currentSlideCooldown = cooldown;
            }

            switch(slide)
            {
                case 1:
                    circles[0].SHMRadiusTo(100);
                    break;
            }
        }
    }
}
