using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class ESP : MonoBehaviour
    {
        public static void Enable(Camera main)
        {
            foreach (GhostAI ghostAI in FindObjectsOfType(typeof(GhostAI)))
            {
                Vector3 w2s = main.WorldToScreenPoint(ghostAI.transform.position);
                Vector3 ghostPosition = main.WorldToScreenPoint(ghostAI.raycastPoint.transform.position);

                float ghostNeckMid = Screen.height - ghostPosition.y;
                float ghostBottomMid = Screen.height - w2s.y;
                float ghostTopMid = ghostNeckMid - (ghostBottomMid - ghostNeckMid) / 5;
                float boxHeight = (ghostBottomMid - ghostTopMid);
                float boxWidth = boxHeight / 1.8f;

                if (w2s.z < 0)
                    continue;

                Utils.Drawing.DrawBoxOutline(new Vector2(w2s.x - (boxWidth / 2f), ghostNeckMid), boxWidth, boxHeight, Color.cyan);
            }

            if (Main.ouijaBoard)
            {
                Vector3 vector2 = main.WorldToScreenPoint(Main.ouijaBoard.transform.position);
                if (vector2.z > 0f)
                {
                    GUI.Label(new Rect(new Vector2(vector2.x, Screen.height - (vector2.y + 1f)), new Vector2(100f, 100f)), "<color=#D11500><b>Ouija Board</b></color>");
                }
            }
            if (Main.dnaEvidence)
            {
                Vector3 vector3 = main.WorldToScreenPoint(Main.dnaEvidence.transform.position);
                if (vector3.z > 0f)
                {
                    GUI.Label(new Rect(new Vector2(vector3.x, Screen.height - (vector3.y + 1f)), new Vector2(100f, 100f)), "<color=#FFFFFF><b>Bone</b></color>");
                }
            }
        }
    }
}
