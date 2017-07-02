using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class Move : MonoBehaviour {

	public float xPos;
	
	SerialPort sp = new SerialPort("/dev/tty.usbmodem1431", 9600);

	void Start () {


		sp.Open ();
		sp.ReadTimeout = 1;

	}

	void Update ()  {

		if (sp.IsOpen)  //youtube tutorial's method 
		{
			try
			{
				//string str = sp.ReadLine();
//				Debug.Log(sp.ReadByte());
				xPos = sp.ReadByte();

				xPos = map(xPos, 0, 255, -10, 10);

				//Vector3 temp = new Vector3(0,0,0);

				//

				// UnityScript`

				Vector3 pos = transform.position;
				pos.x = xPos;
				transform.position = pos;

	

//				str.Trim();
//				if(str != null) {
//					xPos = float.Parse(str);
////					Vector3 temp = new Vector3(xPos,0,0);
////					transform.Translate(temp, Space.World);
//					//Debug.Log(map(xPos, 0, 255, -10, 10));
//					Debug.Log(xPos);
//				}
			}
			catch (System.Exception)
			{
				//throw;
			}
		}
	}

	float map ( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}


	void getPortNames ()
	{
		int p = (int)System.Environment.OSVersion.Platform;
		List<string> serial_ports = new List<string> ();

		// this may work on win
//		foreach (string str in SerialPort.GetPortNames()) {
//			Debug.Log (string.Format ("Port : {0}", str));
//		}

		// Are we on Unix?
		if (p == 4 || p == 128 || p == 6) {
			string[] ttys = System.IO.Directory.GetFiles ("/dev/", "tty.*");
			foreach (string dev in ttys) {
				if (dev.StartsWith ("/dev/tty.*"))
					serial_ports.Add (dev);
				Debug.Log (System.String.Format (dev));
			}
		}
	}
}

