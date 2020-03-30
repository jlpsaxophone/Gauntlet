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
    public class Explosion
    {
        ParticleSystem explosion;
        Gauntlet game;
        int bound1;
        int bound2;
        Random random = new Random();
        double timer = 0;

        public Explosion(Gauntlet game, int bound1, int bound2)
        {
            this.game = game;
            this.bound1 = bound1;
            this.bound2 = bound2;
        }

        public void LoadContent(ContentManager content)
        {
            Texture2D particleTexture = content.Load<Texture2D>("particle");
            explosion = new ParticleSystem(game.graphics.GraphicsDevice, 1000, particleTexture, game.spriteBatch);
            explosion.Emitter = new Vector2(100, 100);
            explosion.SpawnPerFrame = 7;

            // Set the SpawnParticle method
            explosion.SpawnParticle = (ref Particle particle) =>
            {
                particle.Position = new Vector2(bound1, bound2);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-100, 100, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(-100, 100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.5f * new Vector2(0, (float)random.NextDouble());
                particle.Color = Color.Orange;
                particle.Scale = 1f;
                particle.Life = 3f;
            };

            // Set the UpdateParticle method
            explosion.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };
        }

        public void Update(GameTime timeSpan)
        {
            timer += timeSpan.ElapsedGameTime.TotalSeconds;
            if(timer <= 3)
            {
                explosion.Update(timeSpan);
            }
            explosion.Update(timeSpan);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(timer <= 1)
            {
                explosion.Draw();
            }
        }
    }
}
