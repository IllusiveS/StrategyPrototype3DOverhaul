using UnityEngine;
using System.Collections;

public class SystemMessage{

	string message = null;

	public SystemMessage(int points, string reason, Player player)
	{
		message = "<color=#"+player.ColorToHex()+">"+player.Name+"</color> recieved " + points.ToString() + " from " + reason;
	}

	public override string ToString ()
	{
		return message;
	}
}
