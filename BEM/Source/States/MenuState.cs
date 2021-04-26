using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BEM.Source;

namespace BEM.States
{
  public class MenuState : State //class used from https://www.youtube.com/watch?v=76Mz7ClJLoE&t=329s
    {
    private List<Component> _components;
    private SpriteFont font;

    public MenuState(Game1 game, GraphicsDevice graphicsDevice) 
      : base(game, graphicsDevice)
    {
      var buttonTexture = Globals.content.Load<Texture2D>("bin/Windows/Content/Buttons/Button");
      var buttonFont = Globals.content.Load<SpriteFont>("bin/Windows/Content/Fonts/small_Font");
      font = Globals.content.Load<SpriteFont>("bin\\Windows\\Content\\Fonts\\Font");

      var newGameButton = new Button(buttonTexture, buttonFont)
      {
        Position = new Vector2(236, 200),
        Text = "New Game",
      };

      newGameButton.Click += NewGameButton_Click;

      var quitGameButton = new Button(buttonTexture, buttonFont)
      {
        Position = new Vector2(236, 250),
        Text = "Quit Game",
      };

      quitGameButton.Click += QuitGameButton_Click;

      _components = new List<Component>()
      {
        newGameButton,
        quitGameButton,
      };
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();

      Globals._spriteBatch.DrawString(font, "Zamble", new Vector2(225, 70), Color.IndianRed);
      foreach (var component in _components)
        component.Draw(gameTime, spriteBatch);

      spriteBatch.End();
    }

    private void LoadGameButton_Click(object sender, EventArgs e)
    {
      Console.WriteLine("Load Game");
    }

    private void NewGameButton_Click(object sender, EventArgs e)
    {
      _game.ChangeState(new GameState(_game, _graphicsDevice));
    }

    public override void PostUpdate(GameTime gameTime)
    {
      // remove sprites if they're not needed
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var component in _components)
        component.Update(gameTime);
    }

    private void QuitGameButton_Click(object sender, EventArgs e)
    {
      _game.Exit();
    }
  }
}
