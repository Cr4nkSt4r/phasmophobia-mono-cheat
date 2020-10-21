using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class Fullbright
    {
        public static void Enable()
        {
            light = boneTransform.gameObject.AddComponent<Light>();
            light.color = Color.white;
            light.type = LightType.Spot;
            light.shadows = LightShadows.None;
            light.range = 99f;
            light.spotAngle = 9999f;
            light.intensity = 0.3f;
        }

        public static void Disable()
        {
            UnityEngine.Object.Destroy(Main.myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head).GetComponent<Light>());
        }

        private static Transform boneTransform = Main.myPlayer.charAnim.GetBoneTransform(HumanBodyBones.Head);
        private static Light light = boneTransform.GetComponent<Light>();
    }
}
