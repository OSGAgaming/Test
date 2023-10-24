using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
    public class World : IUpdate, IDraw
    {
        public List<Entity> entities;

        public World()
        {
            entities = new List<Entity>();
            LoadEntities();
        }

        public virtual void LoadEntities() { }
        public virtual void OnUpdate() { }

        public void Draw(SpriteBatch sb)
        {
            foreach (Entity entity in entities)
            {
                if (entity is IDraw drawable) drawable.Draw(sb);
            }
        }

        public void Update()
        {
            OnUpdate();
            foreach (Entity entity in entities)
            {
                if (entity is IUpdate updateable) updateable.Update();
            }
        }

        public Entity AddEntity(Entity entitiy)
        {
            entities.Add(entitiy);
            return entitiy;
        }

        public Entity RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
            return entity;
        }
    }
}
