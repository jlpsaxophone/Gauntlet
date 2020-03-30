using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Gauntlet
{
    public class Meteor
    {
        Gauntlet game;
        GraphicsDeviceManager graphics;
        int bound1;
        int bound2;
        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;
        Random random = new Random();

        int type;

        public Meteor(Gauntlet game, GraphicsDeviceManager graphics, int bound1, int bound2, int type)
        {
            this.game = game;
            this.graphics = graphics;
            this.bound1 = bound1;
            this.bound2 = bound2;
            this.type = type;
        }

        public void LoadContent(ContentManager content)
        {
            bounds.X = bound1;
            bounds.Y = bound2;
            if (type == 1)
            {
                texture = content.Load<Texture2D>("bigmeteor");
                bounds.Width = 117;
                bounds.Height = 117;               
            }
            else
            {
                texture = content.Load<Texture2D>("meteor");
                if (type == 2)
                {
                    bounds.Width = 39;
                    bounds.Height = 39;
                }
                if (type == 3)
                {
                    bounds.Width = 78;
                    bounds.Height = 78;
                }
            }            
        }

        public void Update(GameTime timeSpan)
        {
            if(type == 2)
            {
                bounds.Y += (float)(.5 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }
            if (type == 3)
            {
                bounds.Y += (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);           
        }
    }
}
