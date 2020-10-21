using UnityEngine;
using OPS.AntiCheat.Detector;
using System;
using System.Threading;
using OPS.AntiCheat;
using System.Windows.Forms;
using ExitGames.Demos.DemoPunVoice;
using UnityEngine.InputSystem;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace PhasmoMonoCheat
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            new Thread(() =>
            {
                while (true)
                {
                    StartCoroutine(CollectGameObjects());

                    Thread.Sleep(5000);
                }
            }).Start();
        }

        private void Update()
        {
            StartCoroutine(KeyHandler());
        }

        private void OnGUI()
        {
            if (myPlayer != null)
            {
                GUI.Label(new Rect(0f, 0f, 500f, 160f), "", "box");
                GUI.Label(new Rect(10f, 2f, 300f, 50f), "<color=#00FF00><b>Ghost Name:</b> " + ghostAI.ghostInfo.ghostTraits.ghostName.ToString() + " - " + ghostAI.ghostInfo.ghostTraits.ghostAge.ToString() + "</color>");
                GUI.Label(new Rect(10f, 17f, 300f, 50f), "<color=#00FF00><b>Ghost Type:</b> " + ghostAI.ghostInfo.ghostTraits.ghostType.ToString() + "</color>");
                GUI.Label(new Rect(10f, 62f, 400f, 50f), "<color=#00FF00><b>Responds to:</b> " + (ghostAI.ghostInfo.ghostTraits.isShy ? "People that are alone" : "Everyone") + "</color>");
                GUI.Label(new Rect(10f, 77f, 300f, 50f), "<color=#00FF00><b>My Insanity:</b> " + Math.Round(100 - myPlayer.insanity, 0) + "</color>");

                switch (ghostAI.ghostInfo.ghostTraits.ghostType)
                {
                    case GhostTraits.Type.Spirit:
                        evidence = "Spirit Box | Fingerprints | Ghost Writing";
                        break;
                    case GhostTraits.Type.Shade:
                        evidence = "EMF 5 | Fingerprints | Ghost Writing";
                        break;
                    case GhostTraits.Type.Poltergeist:
                        evidence = "Spirit Box | Fingerprints | Ghost Orb";
                        break;
                    case GhostTraits.Type.Jinn:
                        evidence = "EMF 5 | Spirit Box | Ghost Orb";
                        break;
                    case GhostTraits.Type.Mare:
                        evidence = "Spirit Box | Ghost Orb | Freezing Temp.";
                        break;
                    case GhostTraits.Type.Phantom:
                        evidence = "EMF 5 | Ghost Orb | Freezing Temp.";
                        break;
                    case GhostTraits.Type.Wraith:
                        evidence = "Spirit Box | Fingerprints | Freezing Temp.";
                        break;
                    case GhostTraits.Type.Banshee:
                        evidence = "EMF 5 | Fingerprints | Freezing Temp.";
                        break;
                    case GhostTraits.Type.Revenant:
                        evidence = "EMF 5 | Fingerprints | Ghost Writing";
                        break;
                    case GhostTraits.Type.Yurei:
                        evidence = "Ghost Orb | Ghost Writing | Freezing Temp.";
                        break;
                    case GhostTraits.Type.Oni:
                        evidence = "EMF 5 | Spirit Box | Ghost Writing";
                        break;
                    case GhostTraits.Type.Demon:
                        evidence = "Spirit Box | Ghost Writing | Freezing Temp.";
                        break;
                    default:
                        break;
                }
                GUI.Label(new Rect(10f, 47f, 400f, 50f), "<color=#00FF00><b>Evidence:</b> " + evidence + "</color>");

                switch (ghostAI.state)
                {
                    case GhostAI.States.idle:
                        ghostState = "Idle";
                        break;
                    case GhostAI.States.wander:
                        ghostState = "Wander";
                        break;
                    case GhostAI.States.hunting:
                        ghostState = "Hunting";
                        break;
                    case GhostAI.States.favouriteRoom:
                        ghostState = "Favourite Room";
                        break;
                    case GhostAI.States.light:
                        ghostState = "Light";
                        break;
                    case GhostAI.States.door:
                        ghostState = "Door";
                        break;
                    case GhostAI.States.throwing:
                        ghostState = "Throwing";
                        break;
                    case GhostAI.States.fusebox:
                        ghostState = "Fusebox";
                        break;
                    case GhostAI.States.appear:
                        ghostState = "Appear";
                        break;
                    case GhostAI.States.doorKnock:
                        ghostState = "Knock Door";
                        break;
                    case GhostAI.States.windowKnock:
                        ghostState = "Knock Window";
                        break;
                    case GhostAI.States.carAlarm:
                        ghostState = "Car Alarm";
                        break;
                    case GhostAI.States.radio:
                        ghostState = "Radio";
                        break;
                    case GhostAI.States.flicker:
                        ghostState = "Flicker";
                        break;
                    case GhostAI.States.lockDoor:
                        ghostState = "Lock Door";
                        break;
                    case GhostAI.States.cctv:
                        ghostState = "CCTV";
                        break;
                    case GhostAI.States.randomEvent:
                        ghostState = "Random Event";
                        break;
                    case GhostAI.States.GhostAbility:
                        ghostState = "Ghost Ability";
                        break;
                    case GhostAI.States.killPlayer:
                        ghostState = "Kill Player";
                        break;
                    case GhostAI.States.sink:
                        ghostState = "Sink";
                        break;
                    case GhostAI.States.sound:
                        ghostState = "Sound";
                        break;
                    case GhostAI.States.painting:
                        ghostState = "Painting";
                        break;
                    case GhostAI.States.mannequin:
                        ghostState = "Mennequin";
                        break;
                    case GhostAI.States.teleportObject:
                        ghostState = "Teleport Object";
                        break;
                    case GhostAI.States.animationObject:
                        ghostState = "Animate Object";
                        break;
                    default:
                        ghostState = "Idle";
                        break;
                }
                GUI.Label(new Rect(10f, 32f, 300f, 50f), "<color=#00FF00><b>Ghost State:</b> " + ghostState + "</color>");

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

                if (CheatToggles.enableEsp == true)
                {
                    GUI.Label(new Rect(10f, 160f, 100f, 50f), "<b><color=#A302B5>ESP:</color> <color=#00C403>On</color></b>");

                    foreach (GhostAI ghostAI in FindObjectsOfType(typeof(GhostAI)))
                    {
                        Vector3 vector = Camera.main.WorldToScreenPoint(ghostAI.transform.position);
                        Vector3 point = Camera.main.WorldToScreenPoint(ghostAI.raycastPoint.transform.position);
                        if (vector.z > 0f)
                        {
                            float num = Mathf.Abs(vector.y - point.y);
                            vector.y = UnityEngine.Screen.height - (vector.y + 1f);
                            Helper.Box(vector.x, vector.y, num / 1.8f, num, Texture2D.whiteTexture);
                            break;
                        }
                    }
                    if (ouijaBoard)
                    {
                        Vector3 vector2 = Camera.main.WorldToScreenPoint(ouijaBoard.transform.position);
                        if (vector2.z > 0f)
                        {
                            GUI.Label(new Rect(new Vector2(vector2.x, (float)UnityEngine.Screen.height - (vector2.y + 1f)), new Vector2(100f, 100f)), "<color=#D11500><b>Ouija Board</b></color>");
                        }
                    }
                    if (dnaEvidence)
                    {
                        Vector3 vector3 = Camera.main.WorldToScreenPoint(dnaEvidence.transform.position);
                        if (vector3.z > 0f)
                        {
                            GUI.Label(new Rect(new Vector2(vector3.x, (float)UnityEngine.Screen.height - (vector3.y + 1f)), new Vector2(100f, 100f)), "<color=#FFFFFF><b>Bone</b></color>");
                        }
                    }
                }
                else
                {
                    GUI.Label(new Rect(10f, 160f, 100f, 50f), "<b><color=#A302B5>ESP:</color> <color=#C40000>Off</color></b>");
                }

                var boneTransform = player.charAnim.GetBoneTransform(HumanBodyBones.Head);
                var light = boneTransform.GetComponent<Light>();
                if (CheatToggles.enableFullbright == true)
                {
                    GUI.Label(new Rect(10f, 175f, 100f, 50f), "<b><color=#A302B5>Fullbright:</color> <color=#00C403>On</color></b>");
                    light = boneTransform.gameObject.AddComponent<Light>();
                    light.color = Color.white;
                    light.type = LightType.Spot;
                    light.shadows = LightShadows.None;
                    light.range = 99f;
                    light.spotAngle = 9999f;
                    light.intensity = 0.3f;
                }
                else
                {
                    GUI.Label(new Rect(10f, 175f, 100f, 50f), "<b><color=#A302B5>Fullbright:</color> <color=#C40000>Off</color></b>");
                    UnityEngine.Object.Destroy(light);
                }
            }
        }

        IEnumerator CollectGameObjects()
        {
            ghostAI = FindObjectOfType<GhostAI>();

            yield return new WaitForSeconds(0.15f);

            player = FindObjectOfType<Player>();

            yield return new WaitForSeconds(0.15f);

            ouijaBoard = FindObjectOfType<OuijaBoard>();

            yield return new WaitForSeconds(0.15f);

            dnaEvidence = FindObjectOfType<DNAEvidence>();

            yield return null;
        }

        IEnumerator KeyHandler()
        {
            var keyboard = Keyboard.current;
            
            if (keyboard.upArrowKey.wasPressedThisFrame)
            {
                CheatToggles.enableEsp = !CheatToggles.enableEsp;
            }
            if (keyboard.downArrowKey.wasPressedThisFrame)
            {
                CheatToggles.enableFullbright = !CheatToggles.enableFullbright;
            }

            yield return new WaitForEndOfFrame();
        }

        private Player myPlayer => GameController.instance.myPlayer.player;

        public static ServerManager serverManager;

        public static GhostAI ghostAI;

        public static Player player;

        public static OuijaBoard ouijaBoard;

        public static DNAEvidence dnaEvidence;

        public static String evidence;

        public static String ghostState;
    }
}
