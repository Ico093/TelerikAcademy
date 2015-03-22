package com.example.task1;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class DisplayMessageActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_display_message);

		TextView intentMessageTextView = (TextView) this
				.findViewById(R.id.intentMessageTextView);

		Intent intent = getIntent();
		String intentExtraString = intent
				.getStringExtra(MainActivity.intentExtraString);

		intentMessageTextView.setText(intentExtraString);
	}
}
