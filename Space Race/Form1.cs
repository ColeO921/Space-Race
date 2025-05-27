using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Race
{

    public partial class spaceRacer : Form
    {
        public spaceRacer()
        {
            InitializeComponent();
        }

        //player variables and objects
        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 3;
        Rectangle player1 = new Rectangle(200, 360, 20, 20);
        Rectangle player1Image = new Rectangle(200, 360, 50, 50);
        Rectangle player2 = new Rectangle(400, 360, 20, 20);
        Rectangle player2Image = new Rectangle(400, 360, 50, 50);

        //key press variables
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        //asteroid variables and lists 
         List<Rectangle> asteroidList = new List<Rectangle>();
        List<int> asteroidSpeeds = new List<int>();
        List<string> asteroidColours = new List<string>();
        List<string> asteroidDirection = new List<string>();

        Random randGen = new Random();
        int randValue = 0;

        //brushes and pens 
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        private void gameEngine_Tick(object sender, EventArgs e)
        {  
            SoundPlayer pointSound = new SoundPlayer(Properties.Resources.point_up);
            SoundPlayer winSound = new SoundPlayer(Properties.Resources.winSound);

            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - 25)
            {
                player1.Y += playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - 25)
            {
                player2.Y += playerSpeed;
            }

            //checks to see if player 1  or 2 scored and adds the score
            if (player1.Y <= 0)
            {
                player1Score++;
                score1Output.Text = $"Player 1 Score: {player1Score}";
                player1.Y = 355;
                pointSound.Play();
                if (player1Score == 3)
                {
                    winnerOutput.Text = "Player 1 Wins!";
                    winSound.Play();
                    gameEngine.Enabled = false;
                }
            }
            else if (player2.Y <= 0)
            {
                player2Score++;
                score2Output.Text = $"Player 2 Score: {player2Score}";
                player2.Y = 355;
                pointSound.Play();
                if (player2Score == 3)
                {
                    winnerOutput.Text = "Player 2 Wins!";
                    winSound.Play();
                    gameEngine.Enabled = false;
                }
            }

            //moves and creates asteroids
            AsteroidMovement();

            //when players intersect with an asteroid
            PlayerContacts();

            //offsets the images to properly align with players 1 and 2
            player1Image.X = player1.X - 15;
            player1Image.Y = player1.Y - 15;
            player2Image.X = player2.X - 15;
            player2Image.Y = player2.Y - 15;

            //remove asteroids that aren't on the screen
            for (int i = 0; i < asteroidList.Count; i++)
            {

                if (asteroidList[i].X > this.Width - 7)
                {
                    ClearLists(i);
                }
                if (asteroidList[i].X < 0)
                {
                    ClearLists(i);
                }
            }


            Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //player 1
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;

                //player 2
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //player 1
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;

                //player 2
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //paints player 1 and 2
            //fills in the rocket image into separate object (this is to avoid getting the image stretched / shrunk)
            e.Graphics.DrawImage(Properties.Resources.rocketPixel_removebg_preview, player1Image);
            e.Graphics.DrawImage(Properties.Resources.rocketPixel_removebg_preview, player2Image);
           
            //draw asteroids
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (asteroidColours[i] == "white")
                {
                    e.Graphics.FillRectangle(whiteBrush, asteroidList[i]);
                }
                else if (asteroidColours[i] == "blue")
                {
                    e.Graphics.FillRectangle(blueBrush, asteroidList[i]);
                }
                else if (asteroidColours[i] == "red")
                {
                    e.Graphics.FillRectangle(redBrush, asteroidList[i]);
                }
            }


        }
        public void AsteroidMovement()
        {
            //move the asteroids across the screen
            for (int i = 0; i < asteroidList.Count; i++)
            {   //moves asteroids left 
                if (asteroidDirection[i] == "left")
                {
                    int x = asteroidList[i].X - asteroidSpeeds[i];
                    asteroidList[i] = new Rectangle(x, asteroidList[i].Y, asteroidList[i].Width, asteroidList[i].Height);
                }
                else // moves asteroids right
                {
                    int x = asteroidList[i].X + asteroidSpeeds[i];
                    asteroidList[i] = new Rectangle(x, asteroidList[i].Y, asteroidList[i].Width, asteroidList[i].Height);
                }
            }

            //creates new asteroids 
            randValue = randGen.Next(1, 101);
            if (randValue < 5)
            {//creates red asteroids: 5% chance
                int y = randGen.Next(20, this.Height - 40);
                Rectangle newAsteroid = new Rectangle(0, y, 7, 5);

                asteroidSpeeds.Add(randGen.Next(5, 8));
                asteroidColours.Add("red");
                asteroidList.Add(newAsteroid);
                asteroidDirection.Add("right");
            }
            else if (randValue < 15)
            {// creates blue asteroids: 10% chance 
                int y = randGen.Next(20, this.Height - 40);
                Rectangle newAsteroid = new Rectangle(this.Width - 7, y, 20, 3);

                asteroidSpeeds.Add(randGen.Next(2, 6));
                asteroidColours.Add("blue");
                asteroidList.Add(newAsteroid);
                asteroidDirection.Add("left");
            }
            else if (randValue < 25)
            {//creates white asteroids: 10% chance
                int y = randGen.Next(20, this.Height - 40);
                Rectangle newAsteroid = new Rectangle(0, y, 20, 3);

                asteroidSpeeds.Add(randGen.Next(2, 6));
                asteroidColours.Add("white");
                asteroidList.Add(newAsteroid);
                asteroidDirection.Add("right");
            }
        }
        public void PlayerContacts()
        {
            //check for collision between the player and asteroid
            for (int i = 0; i < asteroidList.Count; i++)
            {                    
                SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.collisionSound);

                if (player1.IntersectsWith(asteroidList[i]))
                {   //resets the player back to start position
                    player1.Y = 355;
                    collisionSound.Play();
                }
                else if (player2.IntersectsWith(asteroidList[i]))
                {
                    player2.Y = 355;
                    collisionSound.Play();
                }
            }
        }
        public void ClearLists(int i)
        {   //removes values from lists when the asteroids go off the screen
            asteroidList.RemoveAt(i);
            asteroidSpeeds.RemoveAt(i);
            asteroidColours.RemoveAt(i);
            asteroidDirection.RemoveAt(i);
        }
    }
}