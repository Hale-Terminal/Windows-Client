using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Windows.ApplicationModel.Appointments;
using System.IO;

namespace Hale_Terminal.Sound
{
    class Sound
    {
        public void PlaySound()
        {
            using (FileStream stream = File.Open(App.Current.Properties["directory"] + @"\Sounds\IB_Bell.wav", FileMode.Open))
            {
                SoundPlayer player = new SoundPlayer(stream);
                player.Load();
                player.Play();
            }
        }
    }
}
