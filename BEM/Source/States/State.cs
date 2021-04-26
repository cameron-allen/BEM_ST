﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEM.States
{
  public abstract class State  //class used from https://www.youtube.com/watch?v=76Mz7ClJLoE&t=329s
    {
    #region Fields

    protected GraphicsDevice _graphicsDevice;

    protected Game1 _game;

    #endregion

    #region Methods

    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    public abstract void PostUpdate(GameTime gameTime);

    public State(Game1 game, GraphicsDevice graphicsDevice)
    {
      _game = game;

      _graphicsDevice = graphicsDevice;

    }

    public abstract void Update(GameTime gameTime);

    #endregion
  }
}
