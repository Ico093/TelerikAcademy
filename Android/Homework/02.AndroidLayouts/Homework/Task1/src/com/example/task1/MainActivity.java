package com.example.task1;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.drawable.BitmapDrawable;
import android.os.Bundle;
import android.support.v4.view.ViewPager.LayoutParams;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageView;
import android.widget.PopupWindow;
import android.widget.PopupWindow.OnDismissListener;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener {

	private final Context context = this;
	private PopupWindow popup;
	private int clickedId;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		((ImageView) this.findViewById(R.id.image1)).setOnClickListener(this);
		((ImageView) this.findViewById(R.id.image2)).setOnClickListener(this);
		clickedId = 0;
	}

	@SuppressLint("NewApi")
	@Override
	public void onClick(View v) {
		
		popup = new PopupWindow(context);
		LayoutInflater layoutInflater = (LayoutInflater) getBaseContext()
				.getSystemService(LAYOUT_INFLATER_SERVICE);

		View popupLayout = layoutInflater.inflate(R.layout.popup, null);

		switch (v.getId()) {
		case R.id.image1:
			((TextView) popupLayout.findViewById(R.id.TextView01))
					.setText("Frist picture");
			((TextView) popupLayout.findViewById(R.id.TextView02))
					.setText("Frist picture1");
			((TextView) popupLayout.findViewById(R.id.TextView03))
					.setText("Frist picture2");
			break;
		case R.id.image2:
			((TextView) popupLayout.findViewById(R.id.TextView01))
					.setText("Second picture");
			((TextView) popupLayout.findViewById(R.id.TextView02))
					.setText("Second picture1");
			((TextView) popupLayout.findViewById(R.id.TextView03))
					.setText("Second picture2");
			break;
		default:
			break;
		}
		clickedId = v.getId();

		popup = new PopupWindow(popupLayout, LayoutParams.WRAP_CONTENT,
				LayoutParams.WRAP_CONTENT);
		popup.setOutsideTouchable(true);
		popup.setBackgroundDrawable(new BitmapDrawable(
			    getApplicationContext().getResources(),
			    Bitmap.createBitmap(1, 1, Bitmap.Config.ARGB_8888)
			));
		popup.setContentView(popupLayout);
		
		popup.showAsDropDown(v);
	}
}
