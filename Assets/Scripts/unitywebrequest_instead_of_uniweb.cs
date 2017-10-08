			// Construct JSON request body.
			JSONObject requestJSON = new JSONObject();
			JSONObject requestConfig = new JSONObject();
			requestConfig.AddField(Constants.GoogleRequestJSONConfigEncodingFieldKey, "FLAC");
			requestConfig.AddField(Constants.GoogleRequestJSONConfigSampleRateFieldKey, "16000");
			requestConfig.AddField(Constants.GoogleRequestJSONConfigLanguageCodeFieldKey, "ru-RU");
			JSONObject requestAudio = new JSONObject();
			requestAudio.AddField(Constants.GoogleRequestJSONAudioContentFieldKey, Convert.ToBase64String(File.ReadAllBytes(flacAudioFilePath)));
			requestJSON.AddField(Constants.GoogleRequestJSONConfigFieldKey, requestConfig);
			requestJSON.AddField(Constants.GoogleRequestJSONAudioFieldKey, requestAudio);

	        string url = Constants.GoogleNonStreamingSpeechToTextURL +
	                     "?" + Constants.GoogleAPIKeyParameterName + "=" + m_APIKey;

			UnityWebRequest www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);

			byte[] bytes = Encoding.UTF8.GetBytes(requestJSON.ToString());
				
			UploadHandlerRaw uH = new UploadHandlerRaw(bytes);
			uH.contentType = "application/json";
			www.uploadHandler = uH;

			www.downloadHandler = new DownloadHandlerBuffer();

			www.SetRequestHeader("Content-Type", "application/json");

			SmartLogger.Log(DebugFlags.GoogleNonStreamingSpeechToText, "sent request");

			yield return www.Send();

			while (!www.isDone)
			{
				yield return null;
			}

			if (www.isError)
			{
				SmartLogger.Log(DebugFlags.GoogleNonStreamingSpeechToText, www.error);
			}
			else
			{
				SmartLogger.Log(DebugFlags.GoogleNonStreamingSpeechToText, "Form upload complete!");
			}

			// Grab the response JSON once the request is done and parse it.
			var responseJSON = new JSONObject(www.downloadHandler.text, int.MaxValue);