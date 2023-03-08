using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public Transform tr;
    public Button btn;
    public InputField num;
    private int floors;
    public string numtxt;
    public Transform camera;

    public bool isCheck;

    float x = 0;
    int y = 0;
    float z = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Create();
        }
    }
    public void Create()
    {
        isCheck = !isCheck;

        if (isCheck)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            string floorsNum = numtxt;
            floors = int.Parse(floorsNum);
            x = floors;
            y = floors;
            z = floors;

            float maxCube = floors * 2 - 1;
            tr.transform.position = new Vector3(-floors, -floors, floors);
            for (int k = 1; k <= maxCube; k++)
            {
                int temp = 0;
                float yy = y;
                if (k < floors) { temp = k; }
                else { temp = floors + (floors - k); }
                for (int i = 1; i <= temp; i++)
                {
                    yy--;
                    x -= 0.5f;
                    float xx = x;
                    for (int j = 1; j <= i; j++)
                    {
                        GameObject pr_cube = Resources.Load("Cube") as GameObject;
                        pr_cube.transform.position = new Vector3(xx, yy, z);
                        Instantiate(pr_cube, tr);
                        xx += 1f;
                    }
                }
                z -= 0.5f;
                x = floors;
                if (k < floors) { y++; }
                else { y--; }

            }
            // btn.interactable = false; 

            watch.Stop();
            UnityEngine.Debug.Log(watch.ElapsedMilliseconds + " ms");
            camera.transform.position = new Vector3(0, (float)floors / 2, -10);
        }
        else
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Destroy(tr.GetChild(i).gameObject);
            }

            Create();
        }
    }

}
