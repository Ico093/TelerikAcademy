package com.example.task1;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends Activity {

	final Context context = this;

	private EditText editTextMain;

	public final static String intentExtraString = "EditTextValue";

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		editTextMain = (EditText) this.findViewById(R.id.editTextMain);
	}

	public void SendIntent(View view) {
		Intent intent = new Intent(this, DisplayMessageActivity.class);

		String editTextValueString = editTextMain.getText().toString();
		intent.putExtra(intentExtraString, editTextValueString);

		startActivity(intent);
	}
}
