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
    public class Powerup
    {
        Gauntlet game;
        GraphicsDeviceManager graphics;
        int bound1;
        int bound2;
        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;
        Random random = new Random();
        ParticleSystem particles;

        public int type;

        public Powerup(Gauntlet game, GraphicsDeviceManager graphics, int bound1, int bound2, int type)
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
                texture = content.Load<Texture2D>("ammo");
                bounds.Width = 15;
                bounds.Height = 42;
            }
            else
            {
                texture = content.Load<Texture2D>("shield");
                bounds.Width = 30;
                bounds.Height = 30;
            }

            Texture2D temp = content.Load<Texture2D>("particle");
            particles = new ParticleSystem(graphics.GraphicsDevice, 1000, temp, game.spriteBatch);
            particles.Emitter = new Vector2(100, 100);
            particles.SpawnPerFrame = 1;

            // Set the SpawnParticle method
            particles.SpawnParticle = (ref Particle particle) =>
            {
                particle.Position = new Vector2((float)bounds.X + (float).5 * bounds.Width - 10, (float)bounds.Y + (float).5 * bounds.Height);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-50, 50, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(0, 100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 1f * new Vector2(0, (float)random.NextDouble());
                particle.Color = Color.LightGoldenrodYellow;
                particle.Scale = 1f;
                particle.Life = 2f;
            };

            // Set the UpdateParticle method
            particles.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };
        }

        public void Update(GameTime timeSpan)
        {
            particles.Update(timeSpan);
            bounds.Y += (float)(.2 * timeSpan.ElapsedGameTime.TotalMilliseconds);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            particles.Draw();
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
