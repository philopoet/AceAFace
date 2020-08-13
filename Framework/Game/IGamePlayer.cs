using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Game
{
    public interface IGamePlayer
    {
        int Score { get;}
        void Played(IGame game, int score);
    }
}
