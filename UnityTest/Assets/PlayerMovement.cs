using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput; 


public class PlayerMovement : MonoBehaviour {

    public PlatformerCharacter2D controller;
    private bool m_Jump;
    private SocketIOComponent socket;
    private readonly object jumpLock = new object();


    private void Awake()
    {
        controller = GetComponent<PlatformerCharacter2D>();
    }


	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        Debug.Log(socket.url);
        socket.Connect();
        socket.On("ping", (SocketIOEvent e) =>
        {
            string ping = e.data.ToString();
            Debug.Log(ping);
            socket.Emit("beat:pong");
        });
        socket.On("jump", Jump);
        socket.On("left", TurnLeft);
        socket.On("right", TurnRight);
        socket.On("run", Run);
	}

    public void Run(SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());

        controller.Run(false, false);
    }


    public void TurnLeft(SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());
        controller.TurnLeft();
    }

    public void TurnRight(SocketIOEvent e)
    {
        Debug.Log(e.data.ToString());
        controller.TurnRight();
    }

    public void Jump(SocketIOEvent e)
    {   
        Debug.Log("here1");
        string data = e.data.ToString();
        data = data.Split(':')[1];
        int magnitude = int.Parse(data.Remove(data.Length - 1));
        Debug.Log("here2");
        controller.RunAndJumpRight(magnitude);
        //controller.Move(1, false, true);

    }
	
	// Update is called once per frame
	void Update () {
        
        if (CrossPlatformInputManager.GetButtonDown("Jump")){
            m_Jump = true;
        }

		
	}

    private void FixedUpdate()
    {
        // Read the inputs.
        //bool crouch = Input.GetKey(KeyCode.LeftControl);
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        controller.Move(1, false, m_Jump);
        m_Jump = false;
    }
}
