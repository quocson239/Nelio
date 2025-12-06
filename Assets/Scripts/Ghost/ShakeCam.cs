using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    public bool ShakeCam(float intensity = 1f)
    {
        impulseSource.GenerateImpulse(intensity);
        return true;
    }
}
