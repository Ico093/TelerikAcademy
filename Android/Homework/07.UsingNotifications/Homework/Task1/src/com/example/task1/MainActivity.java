package com.example.task1;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Notification.BigTextStyle;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends Activity {
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    
    @SuppressLint("NewApi") public void SendNotiifcation(View view){
    	Intent intent = new Intent(this, ReceiverActivity.class);
    	PendingIntent pIntent = PendingIntent.getActivity(this, 0, intent, 0);
    	
    	Notification n  = new Notification.Builder(this)
    	.setContentTitle("New mail from " + "test@gmail.com")
        .setContentText("Subject")
        .setSmallIcon(R.drawable.mario)
        .setContentIntent(pIntent)
        .setAutoCancel(true)
        .setStyle(new Notification.BigTextStyle().bigText("There is something wroooooooooooooooooooooooooooooooooooooooong! Very Wrooooooooooooooo ooooooooooooooong!"))
        .addAction(R.drawable.ok, "Call", pIntent)
        .addAction(R.drawable.delete, "More", pIntent).build();
    	
    	NotificationManager notificationManager = 
    			  (NotificationManager) getSystemService(NOTIFICATION_SERVICE);

    	notificationManager.notify(0, n); 
    }
}
