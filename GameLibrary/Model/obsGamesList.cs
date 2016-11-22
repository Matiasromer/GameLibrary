using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GameLibrary.Model
{
    class obsGamesList : ObservableCollection<Game>
    {
        public obsGamesList() :base()
        {
            this.Add(new Game() { title = "Counter strike:GO", pris = 85.0, dato = new DateTime (2012,8,21), comment = "fast paced FPS game. 5/5, stars if you love FPS this will suit your needs" });
            this.Add(new Game() { title = "The Witcher 3", pris = 280.0, dato = new DateTime (2015,5,19), comment = "Single Player RPG. great story/slaying monster game 5/5 stars. "  });
            this.Add(new Game() { title = "Fallout 4", pris = 349.0, dato = new DateTime (2015,11,10), comment = "Single player RPG sorymode game/Slaying Monster. 4/5 stars" });

        }
    }
}
