using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataPersistence : MonoBehaviour {

	//Save a patient to file to the harddrive.  
	public void SavePatient (PatientInfo patient) {
		//Received help from Unity videos
		BinaryFormatter info = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/patientInfo.dat");

		info.Serialize (file, patient);
		file.Close ();
	
	}
	//Load a patient from file in the hardrive
	PatientInfo LoadPatient (PatientInfo patient) {

		if (File.Exists (Application.persistentDataPath + "patientInfo.dat")) {
			BinaryFormatter info = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/patientInfo.dat", FileMode.Open);
			PatientInfo patient_temp = (PatientInfo)info.Deserialize(file);
			file.Close ();
			return patient_temp;
		}

		return null;

	}
}
