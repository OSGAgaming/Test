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
        public List<ExpandingLine> lines_OOP;
        public List<ExpandingCircle> circles_OOP;

        public List<ExpandingCircle> circles_ECS;

        public int slide;
        public int currentSlideCooldown;
        public int cooldown = 40;
        public override void LoadEntities()
        {
            lines_OOP = new List<ExpandingLine>();
            circles_OOP = new List<ExpandingCircle>();
            circles_ECS = new List<ExpandingCircle>();

            for (int i = 0; i < 7; i++)
            {
                circles_OOP.Add(AddEntity(new ExpandingCircle(0)) as ExpandingCircle);
            }
            for (int i = 0; i < 6; i++)
            {
                lines_OOP.Add(AddEntity(new ExpandingLine(circles_OOP[0].Position, circles_OOP[0].Position)) as ExpandingLine);
            }

            for (int i = 0; i < 12; i++)
            {
                circles_ECS.Add(AddEntity(new ExpandingCircle(0)) as ExpandingCircle);
            }

            circles_OOP[0].Position = new Vector2(
                Main.graphics.PreferredBackBufferWidth / 2, 
                Main.graphics.PreferredBackBufferHeight / 2);

            circles_ECS[0].Position = new Vector2(
                Main.graphics.PreferredBackBufferWidth / 2,
                Main.graphics.PreferredBackBufferHeight / 2);
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

            Color i = Color.IndianRed;
            Color m = Color.MonoGameOrange;
            Color p = Color.MediumPurple;

            switch (slide)
            {
                case 1:
                    circles_ECS[0].SHMRadiusTo(100);
                    break;
                case 2:
                    circles_ECS[0].SHMRadiusTo(80);
                    circles_ECS[0].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 100,
                        Main.graphics.PreferredBackBufferHeight / 2) - circles_ECS[0].Position) / 16f;

                    circles_ECS[1].SHMRadiusTo(40);
                    circles_ECS[1].Position = new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2 - 120);
                    circles_ECS[1].RecipColorTo(Color.IndianRed);

                    circles_ECS[2].SHMRadiusTo(40);
                    circles_ECS[2].Position = new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2);
                    circles_ECS[2].RecipColorTo(Color.MonoGameOrange);

                    circles_ECS[3].SHMRadiusTo(40);
                    circles_ECS[3].Position = new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2 + 120);
                    circles_ECS[3].RecipColorTo(Color.MediumPurple);

                    break;
                case 3:
                    circles_ECS[0].RecipColorTo(Color.IndianRed);
                    circles_ECS[1].Position += (circles_ECS[0].Position - circles_ECS[1].Position) / 16f;
                    circles_ECS[1].SHMRadiusTo(0);
                    circles_ECS[1].RecipColorTo(Color.Transparent);
                    break;
                case 4:

                    circles_ECS[0].RecipColorTo(new Color((i.R + m.R) / 2, (i.G + m.G) / 2, (i.B + m.B) / 2));
                    circles_ECS[2].Position += (circles_ECS[0].Position - circles_ECS[2].Position) / 16f;
                    circles_ECS[2].SHMRadiusTo(0);
                    circles_ECS[2].RecipColorTo(Color.Transparent);
                    break;
                case 5:
                    circles_ECS[0].RecipColorTo(new Color((i.R + m.R + p.R) / 3, (i.G + m.G + p.G) / 3, (i.B + m.B + p.B) / 3));
                    circles_ECS[3].Position += (circles_ECS[0].Position - circles_ECS[3].Position) / 16f;
                    circles_ECS[3].SHMRadiusTo(0);
                    circles_ECS[3].RecipColorTo(Color.Transparent);
                    break;
                case 6:
                    circles_ECS[0].SHMRadiusTo(50);
                    circles_ECS[0].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 100,
                        Main.graphics.PreferredBackBufferHeight / 2) - circles_ECS[0].Position) / 16f;

                    circles_ECS[4].SHMRadiusTo(50);
                    circles_ECS[4].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2,
                        Main.graphics.PreferredBackBufferHeight / 2 - 80) - circles_ECS[4].Position) / 16f;
                    circles_ECS[4].RecipColorTo(new Color((i.R + m.R + p.R) / 3, (i.G + m.G + p.G) / 3, (i.B + m.B + p.B) / 3));

                    circles_ECS[5].SHMRadiusTo(50);
                    circles_ECS[5].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 50,
                        Main.graphics.PreferredBackBufferHeight / 2 + 80) - circles_ECS[5].Position) / 16f;
                    circles_ECS[5].RecipColorTo(new Color((i.R + m.R + p.R) / 3, (i.G + m.G + p.G) / 3, (i.B + m.B + p.B) / 3));

                    break;
                case 7:
                    circles_ECS[0].SHMRadiusTo(40);
                    circles_ECS[0].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 250,
                        Main.graphics.PreferredBackBufferHeight / 2) - circles_ECS[0].Position) / 16f;

                    circles_ECS[4].SHMRadiusTo(40);
                    circles_ECS[4].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 150,
                        Main.graphics.PreferredBackBufferHeight / 2 - 80) - circles_ECS[4].Position) / 16f;
                    circles_ECS[4].RecipColorTo(new Color((i.R + m.R + p.R) / 3, (i.G + m.G + p.G) / 3, (i.B + m.B + p.B) / 3));

                    circles_ECS[5].SHMRadiusTo(40);
                    circles_ECS[5].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 100,
                        Main.graphics.PreferredBackBufferHeight / 2 + 80) - circles_ECS[5].Position) / 16f;
                    circles_ECS[5].RecipColorTo(new Color((i.R + m.R + p.R) / 3, (i.G + m.G + p.G) / 3, (i.B + m.B + p.B) / 3));

                    circles_ECS[6].SHMRadiusTo(40);
                    circles_ECS[6].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 50 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2 - 30 - 50) - circles_ECS[6].Position) / 16f;
                    circles_ECS[6].RecipColorTo(Color.DarkSeaGreen);

                    circles_ECS[7].SHMRadiusTo(40);
                    circles_ECS[7].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 50 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2 - 160 - 50) - circles_ECS[7].Position) / 16f;
                    circles_ECS[7].RecipColorTo(Color.DarkSeaGreen);

                    circles_ECS[8].SHMRadiusTo(40);
                    circles_ECS[8].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 100 + 100,
                        Main.graphics.PreferredBackBufferHeight / 2 - 50 - 50) - circles_ECS[8].Position) / 16f;
                    circles_ECS[8].RecipColorTo(Color.DarkSeaGreen);

                    circles_ECS[9].SHMRadiusTo(40);
                    circles_ECS[9].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 - 50 + 200,
                        Main.graphics.PreferredBackBufferHeight / 2 - 30  + 250) - circles_ECS[9].Position) / 16f;
                    circles_ECS[9].RecipColorTo(Color.LightGoldenrodYellow);

                    circles_ECS[10].SHMRadiusTo(40);
                    circles_ECS[10].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 50 + 200,
                        Main.graphics.PreferredBackBufferHeight / 2 - 160 + 250) - circles_ECS[10].Position) / 16f;
                    circles_ECS[10].RecipColorTo(Color.LightGoldenrodYellow);

                    circles_ECS[11].SHMRadiusTo(40);
                    circles_ECS[11].Position += (new Vector2(
                        Main.graphics.PreferredBackBufferWidth / 2 + 100 + 200,
                        Main.graphics.PreferredBackBufferHeight / 2 - 50 + 250) - circles_ECS[11].Position) / 16f;
                    circles_ECS[11].RecipColorTo(Color.LightGoldenrodYellow);

                    break;
                case 9:
                    for (int a = 0; a < circles_ECS.Count; a++)
                    {
                        circles_ECS[a].RecipColorTo(Color.Transparent);
                    }
                    circles_OOP[0].SHMRadiusTo(100);
                    break;
                case 10:
                    circles_OOP[0].SHMRadiusTo(50);
                    circles_OOP[0].Position += (new Vector2(Main.graphics.PreferredBackBufferWidth / 2, 100) - circles_OOP[0].Position) / 16f;
                    circles_OOP[0].Position += (new Vector2(Main.graphics.PreferredBackBufferWidth / 2, 100) - circles_OOP[0].Position) / 16f;

                    lines_OOP[0].p1 = circles_OOP[0].Position;
                    lines_OOP[0].SHMTo(1, circles_OOP[0].Position, circles_OOP[1].Position, 0.01f);

                    lines_OOP[1].p1 = circles_OOP[0].Position;
                    lines_OOP[1].SHMTo(1, circles_OOP[0].Position, circles_OOP[2].Position, 0.01f);

                    circles_OOP[1].Position = new Vector2(Main.graphics.PreferredBackBufferWidth / 2.5f, 300);
                    circles_OOP[1].SHMRadiusTo(30);

                    circles_OOP[2].Position = new Vector2(((2.5f - 1) * Main.graphics.PreferredBackBufferWidth) / 2.5f, 300);
                    circles_OOP[2].SHMRadiusTo(30);

                    break;
                case 11:
                    circles_OOP[0].SHMRadiusTo(50);
                    circles_OOP[0].Position += (new Vector2(Main.graphics.PreferredBackBufferWidth / 2, 100) - circles_OOP[0].Position) / 16f;
                    circles_OOP[0].Position += (new Vector2(Main.graphics.PreferredBackBufferWidth / 2, 100) - circles_OOP[0].Position) / 16f;

                    lines_OOP[0].p1 = circles_OOP[0].Position;
                    lines_OOP[0].SHMTo(1, circles_OOP[0].Position, circles_OOP[1].Position, 0.01f);

                    lines_OOP[1].p1 = circles_OOP[0].Position;
                    lines_OOP[1].SHMTo(1, circles_OOP[0].Position, circles_OOP[2].Position, 0.01f);

                    circles_OOP[1].Position = new Vector2(Main.graphics.PreferredBackBufferWidth / 2.5f, 300);
                    circles_OOP[1].SHMRadiusTo(30);

                    circles_OOP[2].Position = new Vector2(((2.5f - 1) * Main.graphics.PreferredBackBufferWidth) / 2.5f, 300);
                    circles_OOP[2].SHMRadiusTo(30);

                    circles_OOP[3].Position = new Vector2(Main.graphics.PreferredBackBufferWidth / 2.5f - 50, 600);
                    circles_OOP[3].SHMRadiusTo(30);

                    circles_OOP[4].Position = new Vector2(((2.5f - 1) * Main.graphics.PreferredBackBufferWidth) / 2.5f - 70, 500);
                    circles_OOP[4].SHMRadiusTo(20);

                    circles_OOP[5].Position = new Vector2(((2.5f - 1) * Main.graphics.PreferredBackBufferWidth) / 2.5f, 500);
                    circles_OOP[5].SHMRadiusTo(20);

                    circles_OOP[6].Position = new Vector2(((2.5f - 1) * Main.graphics.PreferredBackBufferWidth) / 2.5f + 70, 500);
                    circles_OOP[6].SHMRadiusTo(20);

                    lines_OOP[2].p1 = circles_OOP[1].Position;
                    lines_OOP[2].SHMTo(1, circles_OOP[1].Position, circles_OOP[3].Position, 0.01f);

                    lines_OOP[3].p1 = circles_OOP[2].Position;
                    lines_OOP[3].SHMTo(1, circles_OOP[2].Position, circles_OOP[4].Position, 0.01f);

                    lines_OOP[4].p1 = circles_OOP[2].Position;
                    lines_OOP[4].SHMTo(1, circles_OOP[2].Position, circles_OOP[5].Position, 0.01f);

                    lines_OOP[5].p1 = circles_OOP[2].Position;
                    lines_OOP[5].SHMTo(1, circles_OOP[2].Position, circles_OOP[6].Position, 0.01f);

                    break;
            }
        }
    }
}
