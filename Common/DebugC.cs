using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class DebugC
    {
        public static void PrintObjects()
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (GameObject go in allObjects)
            {
                con.WriteLine("[*] GameObject Name:" + go.name);
            }
        }

        private static Utils.ConsoleWriter con = new Utils.ConsoleWriter();
    }
}
