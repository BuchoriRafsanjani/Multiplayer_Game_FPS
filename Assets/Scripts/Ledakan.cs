using UnityEngine;

public class Ledakan : MonoBehaviour
{

    public GameObject particleLedakan;
    void Update () {
        Destroy(GameObject.Find("ExplosionMobile(Clone)")); //Mengatasi Memori Leak Explosion yang berlebihan walaupun masih belum sempurna :D
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint cp = collision.contacts[0];
        Quaternion rotasi = Quaternion.FromToRotation(Vector3.up, cp.normal);
        GameObject.Instantiate(particleLedakan, cp.point, rotasi);
        Destroy(gameObject);
    }
}