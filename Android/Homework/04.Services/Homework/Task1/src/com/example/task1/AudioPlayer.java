package com.example.task1;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.os.IBinder;

public class AudioPlayer extends Service {

	private final Context context=this;
	private MediaPlayer player;
	
	@Override
	public IBinder onBind(Intent intent) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void onCreate() {
		super.onCreate();
		player = MediaPlayer.create(context, R.raw.song);
        player.setLooping(true);
        player.setVolume(100,100);
	}
	
	@Override
	public int onStartCommand(Intent intent, int flags, int startId) {
		player.start();
		return 1;
	}
	
	@Override
	public void onDestroy() {
		super.onDestroy();
		
		player.stop();
		player.release();
	}

}
