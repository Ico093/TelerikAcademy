package com.example.task1;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends Activity implements OnClickListener {

	private final Context context = this;

	private TextView playOrNotTextView;
	private Button previousButton;
	private Button playButton;
	private Button nextButton;

	private boolean isPlaying;
	private Intent serviceStartStopIntent;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		playOrNotTextView = (TextView) this
				.findViewById(R.id.textViewPlayOrNot);
		previousButton = (Button) this.findViewById(R.id.buttonPrevious);
		playButton = (Button) this.findViewById(R.id.buttonPlay);
		nextButton = (Button) this.findViewById(R.id.buttonNext);
		
		previousButton.setOnClickListener(this);
		playButton.setOnClickListener(this);
		nextButton.setOnClickListener(this);
		
		serviceStartStopIntent = new Intent(context, AudioPlayer.class);
		isPlaying=false;
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.buttonPrevious:	

			break;
		case R.id.buttonPlay:
			if (!isPlaying) {
				startService(serviceStartStopIntent);
				playOrNotTextView.setText("Playing...");
				isPlaying = true;
			} else {
				stopService(serviceStartStopIntent);
				playOrNotTextView.setText("Not Playing");
				isPlaying = false;
			}
			break;
		case R.id.buttonNext:

			break;
		default:
			break;
		}

	}
}
