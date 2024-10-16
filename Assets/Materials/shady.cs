//Shady
using UnityEngine;

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] private Material Mat;
    [SerializeField] private Light SpotLight;

    void Update()
    {
        Mat.SetVector("MyLightPosition", SpotLight.transform.position);
        Mat.SetVector("MyLightDirection", -SpotLight.transform.forward);
        Mat.SetFloat("MyLightAngle", SpotLight.spotAngle);
    }//Update() end
}//class end