using UnityEngine;

namespace PhasmoMonoCheat.Common
{
    class Fullbright
    {
        public static void Enable(Light light, Transform boneTransform)
        {
            light = boneTransform.gameObject.AddComponent<Light>();
            light.color = Color.white;
            light.type = LightType.Spot;
            light.shadows = LightShadows.None;
            light.range = 99f;
            light.spotAngle = 9999f;
            light.intensity = 0.3f;
        }

        public static void Disable(Light light)
        {
            UnityEngine.Object.Destroy(light);
        }
    }
}
