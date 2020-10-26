using System;
using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class BasicInformations
    {
        public static void Enable()
        {
            GUI.Label(new Rect(0f, 0f, 500f, 160f), "", "box");
            GUI.Label(new Rect(10f, 2f, 300f, 50f), "<color=#00FF00><b>Ghost Name:</b> " + Main.ghostAI.ghostInfo.ghostTraits.ghostName.ToString() + " - " + Main.ghostAI.ghostInfo.ghostTraits.ghostAge.ToString() + "</color>");
            GUI.Label(new Rect(10f, 17f, 300f, 50f), "<color=#00FF00><b>Ghost Type:</b> " + Main.ghostAI.ghostInfo.ghostTraits.ghostType.ToString() + "</color>");
            GUI.Label(new Rect(10f, 62f, 400f, 50f), "<color=#00FF00><b>Responds to:</b> " + (Main.ghostAI.ghostInfo.ghostTraits.isShy ? "People that are alone" : "Everyone") + "</color>");
            GUI.Label(new Rect(10f, 77f, 300f, 50f), "<color=#00FF00><b>My Sanity:</b> " + Math.Round(100 - Main.myPlayer.insanity, 0) + "</color>");

            var counter = 1;
            foreach (PlayerData player in GameController.instance.playersData)
            {
                if(player != null && !player.player.isDead)
                    GUI.Label(new Rect(10f, 175f + (counter * 15f), 300f, 50f), "<color=#00FF00><b>" + player.playerName + " Sanity:</b> " + Math.Round(100 - player.player.insanity, 0) + "</color>");
                counter++;
            }
        
            switch (Main.ghostAI.ghostInfo.ghostTraits.ghostType)
            {
                case GhostTraits.Type.Spirit:
                    Main.evidence = "Spirit Box | Fingerprints | Ghost Writing";
                    break;
                case GhostTraits.Type.Shade:
                    Main.evidence = "EMF 5 | Fingerprints | Ghost Writing";
                    break;
                case GhostTraits.Type.Poltergeist:
                    Main.evidence = "Spirit Box | Fingerprints | Ghost Orb";
                    break;
                case GhostTraits.Type.Jinn:
                    Main.evidence = "EMF 5 | Spirit Box | Ghost Orb";
                    break;
                case GhostTraits.Type.Mare:
                    Main.evidence = "Spirit Box | Ghost Orb | Freezing Temp.";
                    break;
                case GhostTraits.Type.Phantom:
                    Main.evidence = "EMF 5 | Ghost Orb | Freezing Temp.";
                    break;
                case GhostTraits.Type.Wraith:
                    Main.evidence = "Spirit Box | Fingerprints | Freezing Temp.";
                    break;
                case GhostTraits.Type.Banshee:
                    Main.evidence = "EMF 5 | Fingerprints | Freezing Temp.";
                    break;
                case GhostTraits.Type.Revenant:
                    Main.evidence = "EMF 5 | Fingerprints | Ghost Writing";
                    break;
                case GhostTraits.Type.Yurei:
                    Main.evidence = "Ghost Orb | Ghost Writing | Freezing Temp.";
                    break;
                case GhostTraits.Type.Oni:
                    Main.evidence = "EMF 5 | Spirit Box | Ghost Writing";
                    break;
                case GhostTraits.Type.Demon:
                    Main.evidence = "Spirit Box | Ghost Writing | Freezing Temp.";
                    break;
                default:
                    break;
            }
            GUI.Label(new Rect(10f, 47f, 400f, 50f), "<color=#00FF00><b>Evidence:</b> " + Main.evidence + "</color>");

            switch (Main.ghostAI.state)
            {
                case GhostAI.States.idle:
                    Main.ghostState = "Idle";
                    break;
                case GhostAI.States.wander:
                    Main.ghostState = "Wander";
                    break;
                case GhostAI.States.hunting:
                    Main.ghostState = "Hunting";
                    break;
                case GhostAI.States.favouriteRoom:
                    Main.ghostState = "Favourite Room";
                    break;
                case GhostAI.States.light:
                    Main.ghostState = "Light";
                    break;
                case GhostAI.States.door:
                    Main.ghostState = "Door";
                    break;
                case GhostAI.States.throwing:
                    Main.ghostState = "Throwing";
                    break;
                case GhostAI.States.fusebox:
                    Main.ghostState = "Fusebox";
                    break;
                case GhostAI.States.appear:
                    Main.ghostState = "Appear";
                    break;
                case GhostAI.States.doorKnock:
                    Main.ghostState = "Knock Door";
                    break;
                case GhostAI.States.windowKnock:
                    Main.ghostState = "Knock Window";
                    break;
                case GhostAI.States.carAlarm:
                    Main.ghostState = "Car Alarm";
                    break;
                case GhostAI.States.radio:
                    Main.ghostState = "Radio";
                    break;
                case GhostAI.States.flicker:
                    Main.ghostState = "Flicker";
                    break;
                case GhostAI.States.lockDoor:
                    Main.ghostState = "Lock Door";
                    break;
                case GhostAI.States.cctv:
                    Main.ghostState = "CCTV";
                    break;
                case GhostAI.States.randomEvent:
                    Main.ghostState = "Random Event";
                    break;
                case GhostAI.States.GhostAbility:
                    Main.ghostState = "Ghost Ability";
                    break;
                case GhostAI.States.killPlayer:
                    Main.ghostState = "Kill Player";
                    break;
                case GhostAI.States.sink:
                    Main.ghostState = "Sink";
                    break;
                case GhostAI.States.sound:
                    Main.ghostState = "Sound";
                    break;
                case GhostAI.States.painting:
                    Main.ghostState = "Painting";
                    break;
                case GhostAI.States.mannequin:
                    Main.ghostState = "Mennequin";
                    break;
                case GhostAI.States.teleportObject:
                    Main.ghostState = "Teleport Object";
                    break;
                case GhostAI.States.animationObject:
                    Main.ghostState = "Animate Object";
                    break;
                default:
                    Main.ghostState = "Idle";
                    break;
            }
            GUI.Label(new Rect(10f, 32f, 300f, 50f), "<color=#00FF00><b>Ghost State:</b> " + Main.ghostState + "</color>");

            int missionNum = 1;
            foreach (Mission mission in MissionManager.instance.currentMissions)
            {
                GUI.Label(new Rect(10f, 80f + (float)missionNum * 15f, 600f, 50f), string.Concat(new object[]
                {
                "<color=#00FF00>",
                ((mission.completed) ? "<i>" : ""),
                "<b>" + missionNum + "</b>",
                ") ",
                mission.missionName,
                ((mission.completed) ? "</i>" : ""),
                "</color>"
                }));
                missionNum++;
            }
        }
    }
}
