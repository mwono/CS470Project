using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public Camera cCam;
    public Camera mCam;

    public int distAway, buffer;

    void Awake()
    {
        this.transform.position = new Vector3(player.transform.position.x + buffer, 0, distAway);

        mCam.rect = new Rect(.5f, 0, .5f, 1);
        cCam.rect = new Rect(0, 0f, .5f, 1);

        SetScissorRect(cCam, new Rect(0, 0, .5f, 1));
        SetScissorRect(mCam, new Rect(.5f, 0, .5f, 1));
    }

    private void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x + buffer, player.transform.position.y, distAway);
    }


    //Credit: https://answers.unity.com/questions/1112309/screen-is-2-cameras-with-each-different-properties.html#answer-1112586
    public static void SetScissorRect(Camera cam, Rect r)
    {
        cam.rect = new Rect(0, 0, 1, 1);
        Matrix4x4 m = cam.projectionMatrix;
        cam.rect = r;
        Matrix4x4 m1 = Matrix4x4.TRS(new Vector3((1 / r.width - 1), (1 / r.height - 1), 0), Quaternion.identity, new Vector3(1 / r.width, 1 / r.height, 1));
        Matrix4x4 m2 = Matrix4x4.TRS(new Vector3(-r.x * 2 / r.width, -r.y * 2 / r.height, 0), Quaternion.identity, Vector3.one);
        cam.projectionMatrix = m2 * m1 * m;
    }
}