using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch
{
    static class Catch
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string controls =
                "Controls:\n\n\n" +
                "P1:\nJump: W\nMove: A, D\nStop Horizontal Momentum: S\n" +
                "Super Jump: 1\nSuper Boost: 2\nFlip Gravity: 3\n\n" +
                "P2:\nJump: Up\nMove: Left, Right\nStop Horizontal Momentum: Down\n" +
                "Super Jump: H\nSuper Boost: J\nFlip Gravity: K\n\n";

            string important =
                "Important!!\n\n" +
                "CATCH THE FRUITS!\n" +
                "If Super Jump/Boost is used, your inputs will be locked for the duration of the ability!" +
                "Every Player Preset has a set number of times an ability can be used before they touch the ground again.\n" +
                "Player Preset 6 cannot change gravity!\n";

            Console.WriteLine(controls + important);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
