using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPatients : MonoBehaviour {

	static public List<PatientInfo> patients;

	public Text radiology;
	public Text patientHistory; ///TODO: pop up window
	public Text medicationsList; ///TODO: pop up window
	public Image pic;
	public Text treatmentPlan;
	public Text name;
	public Text MRN;

	public PatientSamples patient_samples;

	public void Start () {
		patients = new List<PatientInfo> ();

		patient_samples.createPatients ();

		//Search for wanted
		PatientInfo wanted = new PatientInfo();
		wanted.MRN = 513425;

		//Scan the barcode -> MRN -> Search the List for matching copy -> Replace fields 
		PatientInfo temp = new PatientInfo();
		foreach (PatientInfo patient_kind in patients) {
			if (wanted.MRN == patient_kind.MRN)
				temp = patient_kind;
		}

		if (temp != null) {
			patientHistory.text = temp.medicalHistory;
			medicationsList.text = temp.medication;
			treatmentPlan.text = temp.treatmentPlan;
			MRN.text = temp.MRN.ToString();
			name.text = temp.firstName + " " + temp.lastName;
			pic.sprite = temp.profileSprite;
		}
	}
}