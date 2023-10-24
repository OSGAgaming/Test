using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public Circle c1;
        public Circle c2;

        public override void LoadEntities()
        {
            c1 = AddEntity(new Circle(6)) as Circle;
            c2 = AddEntity(new Circle(8)) as Circle;

            c1.Position = new Vector2(50,50);
            c2.Position = new Vector2(190, 100);
        }
    }
}
