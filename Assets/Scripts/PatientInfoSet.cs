using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatientInfoSet {
    public List<PatientInfo> patientInfos;

    public PatientInfoSet(List<PatientInfo> patientInfos)
    {
        this.patientInfos = new List<PatientInfo>();
        this.patientInfos.AddRange(patientInfos);
    }
}
