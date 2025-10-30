using UnityEngine;

public class CameraCheck : MonoBehaviour
{
    void Start()
    {
        if (Camera.main == null)
        {
            Debug.LogError("❌ Không có Camera hoạt động trong scene!");
        }
        else
        {
            Debug.Log("✅ Camera đang hoạt động: " + Camera.main.name);
        }
    }
}
