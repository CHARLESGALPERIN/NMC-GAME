using System.Collections;
using System.Threading;
using UnityEngine;

public class scanTerrain : MonoBehaviour
{
    private float timer;

    private void Start()
    {
        StartCoroutine(loop());
    }
    private IEnumerator scan()
    {
        yield return new WaitForSeconds(0);
        AstarPath.active.Scan();
    }
    private IEnumerator loop()
    {
        yield return new WaitForSeconds(10);
        scan();
        loop();
    }
}
