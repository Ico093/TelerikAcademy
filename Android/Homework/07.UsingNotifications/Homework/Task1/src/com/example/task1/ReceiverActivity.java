package com.example.task1;

import android.app.Activity;
import android.app.NotificationManager;
import android.os.Bundle;

public class ReceiverActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_receiver);
		
		NotificationManager notificationManager = 
	  			  (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
	        
	        notificationManager.cancel(0);
	}
}
