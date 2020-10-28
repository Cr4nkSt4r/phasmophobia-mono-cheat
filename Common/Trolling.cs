using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class Trolling
    {
        public static void StartHunting()
        {
            Main.ghostAI.isHunting = true;
            Main.ghostAI.canAttack = true;
            Main.ghostAI.canEnterHuntingMode = true;
            Main.ghostAI.ghostIsAppeared = true;
            Main.ghostAI.isChasingPlayer = true;
            Main.ghostAI.canWander = true;
            Main.ghostAI.playerToKill = null;
            Main.ghostAI.ChasingPlayer(true);
            Main.ghostAI.ChangeState(GhostAI.States.hunting, null, null);
        }
    }
}
