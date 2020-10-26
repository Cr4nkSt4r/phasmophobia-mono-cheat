using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class Trolling
    {
        public static void StartHunting()
        {
            GhostAI.isHunting = true;
            GhostAI.canAttack = true;
            GhostAI.canEnterHuntingMode = true;
            GhostAI.ghostIsAppeared = true;
            GhostAI.isChasingPlayer = true;
            GhostAI.canWander = true;
            GhostAI.playerToKill = null;
            GhostAI.ChasingPlayer(true);
            GhostAI.ChangeState(GhostAI.States.hunting, null, null);
        }

        private static GhostAI GhostAI;
    }
}
