using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    // float distance;
    // //Vector3 offset = new Vector3(2, -0.5f, -3);//vector right + ofset
    // //float limit;
    // float initial_lerp;
    // float lerp_time;
    // public bool slow;
    // Vector3 last_pos;
    // Vector3 pos;
    // Vector3 pos_final;
    // //OtherCamera stuff
    // Vector3 rot;
    // Vector3 rot_final;

    //int modY, modZ;


    public GameObject player;
    public PlayerFz2 player_controller;    
    public GameObject[] cam_pos;
    int index;
    [Range(0,1)]
    public float lerp_max = 0.2f;
    public float lerp;

    private void Awake()
    {
        if(player==null)
            player = GameObject.Find("Player");
        player_controller = player.GetComponent<PlayerFz2>();

        if(cam_pos[0] == null || cam_pos[1] == null)
        {
            cam_pos[0] = GameObject.Find("TargetRight");
            cam_pos[1] = GameObject.Find("TargetLeft");
        }
    }

    void LateUpdate()
    {
        //CameraWorking();
        //OtherCamera();//camera no player
        //TargetCamera();    
        BestCamera();        
    }

    ///tentativas de camera

    bool last_to_right;
    void BestCamera()
    {
        Vector3 des_pos;//desired position
        Quaternion des_rot;//desired rotation

        //decide qual a camera
        if (player_controller.onRigth == true)
            index = 0;
        else
            index = 1;
        
        des_pos = cam_pos[index].transform.position;
        des_rot = cam_pos[index].transform.rotation;

        //controlla a velocidade do player
        if (lerp <= lerp_max)
            lerp += 0.095f * Time.deltaTime;
        if (last_to_right != player_controller.onRigth)
            lerp = 0;

        last_to_right = player_controller.onRigth;
        //muda a camera

        this.transform.position = Vector3.Lerp(this.transform.position, des_pos, lerp);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, des_rot, lerp);
    }
    



    /////camera Shake
    //https://drive.google.com/file/d/1ZLnll08s5-4kv5dUHqfUvrNugwLSqVdw/view
    //https://www.youtube.com/watch?v=kzHHAdvVkto
    Vector3 cameraInitialPosition;
	public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
	public Camera mainCamera;

	public void ShakeIt()
	{
        mainCamera = this.GetComponent<Camera>();
		cameraInitialPosition = mainCamera.transform.position;
		InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
		Invoke ("StopCameraShaking", shakeTime);
	}

	void StartCameraShaking()
	{
		float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		mainCamera.transform.position = cameraIntermadiatePosition;
	}

	void StopCameraShaking()
	{
		CancelInvoke ("StartCameraShaking");
		mainCamera.transform.position = cameraInitialPosition;
	}
}
