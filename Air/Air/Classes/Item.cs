using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air.Classes
{
    class Item
    {
        //// member variables
        //private PictureBox item;
        //private PictureBox canvas;
        //private Random random = new Random();
        //private int generatePeriod = 3;
        //private int itemCount = 0;
        //private bool generate = false;
        //private string collideTagName;
        //private string itemName;

        //// methods
        //public void init(string itemName, PictureBox canvas)
        //{
        //    this.itemName = itemName;
        //    this.canvas = canvas;
        //}

        //public void draw()
        //{
        //    if (item != null)
        //        item.Location = new Point(item.Location.X, item.Location.Y);
        //}

        //public void update(int frames, int speed, Panel plane, Player player)
        //{
        //    generate = (DateTime.Now.Second % generatePeriod == 0 && item == null) ? true : false;

        //    if (generate && item == null)
        //    {
        //        generateItem(1120, random.Next(100, 500));          // item generate position
        //        generate = false;
        //    }

        //    else if (item != null)
        //    {
        //        item.Left -= speed * frames;

        //        if (item.Location.X < -50)
        //        {
        //            item.Dispose();
        //            item = null;
        //            collideTagName = null;
        //        }

        //        // star : collision with player
        //        else if (item.Location.X > plane.Location.X - player.offset.X && item.Location.X < plane.Location.X + player.offset.X &&
        //            item.Location.Y > plane.Location.Y - player.offset.Y && item.Location.Y < plane.Location.Y + player.offset.Y)
        //            collideTagName = itemName;
        //    }

        //    collisionUpdate();
        //}

        //public void generateItem(int x, int y)
        //{
        //    item = new PictureBox();
        //    item.Image = Air.Properties.Resources.star;
        //    item.SizeMode = PictureBoxSizeMode.StretchImage;
        //    item.BackColor = Color.Transparent;
        //    item.Parent = canvas;
        //    item.Size = new Size(50, 50);
        //    item.Location = new Point(x, y);
        //}

        //private void collisionUpdate()
        //{
        //    if (collideTagName == "Star")
        //    {
        //        itemCount++;

        //        item.Dispose();
        //        item = null;
        //        collideTagName = null;
        //    }

        //    else if (collideTagName == "Air")
        //    {
        //        // Airtank Gage ++
        //    }

        //    else if (collideTagName == "AirResistanceUP")
        //    {
        //        // Air Resistance ++
        //    }

        //    else if (collideTagName == "AirResistanceDown")
        //    {
        //        // Air Resistance --
        //    }

        //    else if (collideTagName == "Wall")
        //    {
        //        // destroy player
        //    }
        //}
    }
}
