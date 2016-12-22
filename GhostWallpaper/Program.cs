using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GhostWallpaper
{
    class Program
    {
        static void setWallpaper()
        {
            var now = int.Parse(DateTime.Now.ToString("HH"));
            var contents = File.ReadAllLines(@"wg\relationship.txt");
            var outlet = "";

            foreach (var line in contents)
            {
                var stuff = line.Split(' ');
                var from = int.Parse(stuff[0]);
                var to = int.Parse(stuff[1]);

                if ((now >= from) && (now < to))
                {
                    outlet = stuff[2];
                }
            }

            if (outlet.Length > 0)
            {
                Wallpaper.SetDesktopWallpaper(@"wg\" + outlet, WallpaperStyle.Stretch);
            }
        }

        static void Main(string[] args)
        {
            int wait = 1000 * 60 * 60;

            while (true)
            {
                setWallpaper();
                Thread.Sleep(wait);
            }
                
        }
    }
}
