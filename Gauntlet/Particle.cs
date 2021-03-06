﻿using Microsoft.Xna.Framework;

namespace Gauntlet
{
    /// <summary>
    /// A struct representing a single particle in a particle system 
    /// </summary>
    public struct Particle
    {
        /// <summary>
        /// The current position of the particle
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// The current velocity of the particle
        /// </summary>
        public Vector2 Velocity;

        /// <summary>
        /// The current acceleration of the particle
        /// </summary>
        public Vector2 Acceleration;

        /// <summary>
        /// The current scale of the particle
        /// </summary>
        public float Scale;

        /// <summary>
        /// The current life of the particle
        /// </summary>
        public float Life;

        /// <summary>
        /// The current color of the particle
        /// </summary>
        public Color Color;
    }
}
