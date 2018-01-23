using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	
	public WheelCollider[] WheelColForward;
	public WheelCollider[] WheelColBack;
	
	public Transform[] wheelsMeshF; 
	public Transform[] wheelsMeshB; 
	
	public float wheelOffset = 0.1f; 
	public float wheelRadius = 0.38f; 
	
	public float maxAngle = 40;
	public float maxAccelerate = 1000;
	public float maxBrake = 1;
	
	public Transform MassCenter;
		
	public class WheelData{ 
		public Transform wheelTransform; 
		public WheelCollider col; 
		public Vector3 wheelStartPos; 
		public float rotation = 0.0f;  
	
	}
	
	protected WheelData[] wheels; 
	
		
	void Start () {
		
		GetComponent<Rigidbody>().centerOfMass = MassCenter.localPosition;
		
		wheels = new WheelData[WheelColForward.Length+WheelColBack.Length]; 
		
		for (int i = 0; i<WheelColForward.Length; i++){ 
			wheels[i] = SetupWheels(wheelsMeshF[i],WheelColForward[i]); 
		}
		
		for (int i = 0; i<WheelColBack.Length; i++){ 
			wheels[i+WheelColForward.Length] = SetupWheels(wheelsMeshB[i],WheelColBack[i]); 
		}
		
	}
	
	
	private WheelData SetupWheels(Transform wheel, WheelCollider col){ 
		WheelData result = new WheelData(); 
		
		result.wheelTransform = wheel;
		result.col = col;
		result.wheelStartPos = wheel.transform.localPosition;
		
		return result; 
		
	}
	
	void FixedUpdate () {
		
		float accel = 0;
		float steer = 0;
				
		accel = Input.GetAxis("Vertical");
		steer = Input.GetAxis("Horizontal");		
		
		CarMove(accel,steer);
		UpdateWheels();
	}
	
	
	private void UpdateWheels(){ 
		float delta = Time.fixedDeltaTime;
		
		
		foreach (WheelData w in wheels){ 
			WheelHit hit; 
								
			Vector3 lp = w.wheelTransform.localPosition; 
			if(w.col.GetGroundHit(out hit)){ 
				lp.y -= Vector3.Dot(w.wheelTransform.position - hit.point, transform.up) - wheelRadius; 
			}else{ 
				
				lp.y = w.wheelStartPos.y - wheelOffset; 
			}
			w.wheelTransform.localPosition = lp;
			
			
			w.rotation = Mathf.Repeat(w.rotation + delta * w.col.rpm * 360.0f / 60.0f, 360.0f); 
			w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.col.steerAngle, 90.0f); 
		}	
		
	}
	
	private void CarMove(float accel,float steer){
		
		foreach(WheelCollider col in WheelColForward){
			col.steerAngle = steer*maxAngle;
		}
		
		if(accel == 0){
			foreach(WheelCollider col in WheelColBack){
				col.brakeTorque = maxBrake;
			}	
			
		}else{
								
			foreach(WheelCollider col in WheelColBack){
				col.brakeTorque = 0;
				col.motorTorque	= accel*maxAccelerate;
			}	
			
		}
		
				
		
	}
	
}