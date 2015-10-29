using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics{get;set;}
        public SpriteBatch spriteBatch{get;set;}

        public IController keyboard { get; set; }
        public IController gamepad{get;set;}
        public IPlayer mario { get; set; }
        public LevelStorage levelStore { get; set; }
        public LevelLoader loader { get; set; }
        public Camera camera { get; set; }
        public CameraController cameraController { get; set; }

        private ICommand keyboardNotPressed;
        private Texture2D background;
        private Texture2D background2;
        private Rectangle mainframe;
        private TestingClass tester;
        private ICommand resetCommand;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            tester = new TestingClass(this);
            keyboard = new KeyboardController();
            gamepad = new GamepadController(this);
            keyboardNotPressed = new KeyNotPressed(this);
            camera = new Camera(480, 800, new Vector2(0, 0));
            loader= new LevelLoader("Level.xml", camera);
            mainframe = new Rectangle(0, 0, 2000, 600);
            levelStore = new LevelStorage(camera);

            base.Initialize();
            tester.runTests();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            BlockSpriteTextureStorage.Load(this.Content);
            ItemSpriteTextureStorage.Load(this.Content);
            EnemySpriteFactory.Load(this.Content);
            MiscGameObjectTextureStorage.Load(this.Content);
            MarioSpriteFactory.Load(this.Content);
            background = Content.Load<Texture2D>("Background");
            background2 = Content.Load<Texture2D>("Background2");

            LoadKeyBoardCommands(); 
            levelStore=loader.LoadLevel();
            mario = levelStore.player;
            cameraController = new CameraController(camera, mario);
            resetCommand = new ResetLevelCommand(this);
        }

        private void LoadKeyBoardCommands()
        {
            ((KeyboardController)keyboard).RegisterCommand(Keys.Z, new UpCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Down, new DownCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Left, new LeftCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Right, new RightCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.X, new FireballCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.R, new ResetLevelCommand(this));
            ((KeyboardController)keyboard).RegisterDiagonalCommands(this);
        }


        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            gamepad.Update();
            keyboardNotPressed.Execute();
            mario.Update();
            levelStore.Update(mario,this);
            cameraController.Update();
            if (((Mario)mario).IsDying)
            {
                resetCommand.Execute();
            }
            if (((int)(((Mario)mario).Location.Y ))> camera.GetHeight())
            {
                resetCommand.Execute();
            }
            base.Update(gameTime);
        }

       

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Rectangle sourceRectangle = new Rectangle((int)camera.GetPosition().X, (int)camera.GetPosition().Y, 800, 480);
            Rectangle destinationRectangle = new Rectangle(0, 0, 800, 480);
            if ((int)camera.GetPosition().X  < 1500) { spriteBatch.Draw(background, destinationRectangle, sourceRectangle, Color.White); }
            else 
            {
                sourceRectangle = new Rectangle((int)camera.GetPosition().X - 1500, (int)camera.GetPosition().Y, 800, 480);
                spriteBatch.Draw(background2, destinationRectangle, sourceRectangle, Color.White); 
            }
            spriteBatch.End();

            levelStore.Draw(mario, spriteBatch);
            base.Draw(gameTime);

        }
    }
}
