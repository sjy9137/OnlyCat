using System.Collections;
using UnityEngine;

public enum EVENT_TYPE{Break,Restart};
public interface IListener{

	void OnEvent(EVENT_TYPE eventType, Component sender, Object param = null);

}
