using PhasmoMonoCheat.Common;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PhasmoMonoCheat
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            con.WriteLine("[+] Injected");
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
                var main = Camera.main;
                var boneTransform = myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head);
                var light = boneTransform.GetComponent<Light>();

                if (CheatToggles.enableBasicInformations == true)
                {
                    BasicInformations.Enable();
                }
                else
                {
                }

                if (CheatToggles.enableEsp == true)
                {
                    GUI.Label(new Rect(10f, 160f, 100f, 50f), "<b><color=#A302B5>ESP:</color> <color=#00C403>On</color></b>");
                    ESP.Enable(main);
                }
                else
                {
                    GUI.Label(new Rect(10f, 160f, 100f, 50f), "<b><color=#A302B5>ESP:</color> <color=#C40000>Off</color></b>");
                }

                if (CheatToggles.enableFullbright == true)
                {
                    GUI.Label(new Rect(10f, 175f, 100f, 50f), "<b><color=#A302B5>Fullbright:</color> <color=#00C403>On</color></b>");
                    Fullbright.Enable(light, boneTransform);
                }
                else
                {
                    GUI.Label(new Rect(10f, 175f, 100f, 50f), "<b><color=#A302B5>Fullbright:</color> <color=#C40000>Off</color></b>");
                    //UnityEngine.Object.Destroy(myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head).GetComponent<Light>());
                    Fullbright.Disable(light);
                }
            }
        }

        IEnumerator CollectGameObjects()
        {
            player = FindObjectOfType<Player>();
            yield return new WaitForSeconds(0.15f);

            ouijaBoard = FindObjectOfType<OuijaBoard>();
            yield return new WaitForSeconds(0.15f);

            dnaEvidence = FindObjectOfType<DNAEvidence>();
            yield return new WaitForSeconds(0.15f);

            ghostAI = FindObjectOfType<GhostAI>();
            yield return null;
        }

        IEnumerator KeyHandler()
        {
            var keyboard = Keyboard.current;

            if (keyboard.upArrowKey.wasPressedThisFrame)
            {
                CheatToggles.enableEsp = !CheatToggles.enableEsp;
                con.WriteLine("[+] ESP: Toggled " + (CheatToggles.enableEsp ? "On" : "Off"));
            }
            if (keyboard.downArrowKey.wasPressedThisFrame)
            {
                CheatToggles.enableFullbright = !CheatToggles.enableFullbright;
                con.WriteLine("[+] Fullbright: Toggled " + (CheatToggles.enableFullbright ? "On" : "Off"));
            }
            if (keyboard.leftArrowKey.wasPressedThisFrame)
            {
                CheatToggles.enableBasicInformations = !CheatToggles.enableBasicInformations;
                con.WriteLine("[+] Basic informations: Toggled " + (CheatToggles.enableBasicInformations ? "On" : "Off"));
            }
            if (keyboard.deleteKey.wasPressedThisFrame)
            {
                con.WriteLine("[+] Unloading");
                if(myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head).GetComponent<Light>() != null)
                    UnityEngine.Object.Destroy(myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head).GetComponent<Light>());
                Loader.Unload();
            }

            yield return new WaitForEndOfFrame();
        }

        private static Utils.ConsoleWriter con = new Utils.ConsoleWriter();
        public static Player myPlayer => GameController.instance.myPlayer.player;
        public static Player player;
        public static OuijaBoard ouijaBoard;
        public static DNAEvidence dnaEvidence;
        public static GhostAI ghostAI;
        public static String evidence;
        public static String ghostState;
    }
}
