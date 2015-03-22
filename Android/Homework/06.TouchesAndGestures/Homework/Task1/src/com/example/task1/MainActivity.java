package com.example.task1;

import android.app.Activity;
import android.content.Context;
import android.gesture.Gesture;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.Point;
import android.os.Bundle;
import android.util.Log;
import android.view.MotionEvent;
import android.view.ScaleGestureDetector;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(new MyCustomClass(this));
	}

	class MyCustomClass extends View {

		private ScaleGestureDetector scaleGestureDetector;
		private Point point;
		private Paint paint;
		private int size;

		public MyCustomClass(Context context) {
			super(context);

			this.scaleGestureDetector = new ScaleGestureDetector(context,
					new ScaleListener());

			this.point = new Point();
			this.paint = new Paint(Paint.ANTI_ALIAS_FLAG);
		}

		@Override
		protected void onLayout(boolean changed, int left, int top, int right,
				int bottom) {

			this.size = (int) ((right - left) * .20f);
			this.point.x = (getWidth() / 2) - this.size / 2;
			this.point.y = (getHeight() / 2) - this.size / 2;

			super.onLayout(changed, left, top, right, bottom);
		}

		@Override
		public boolean onTouchEvent(MotionEvent event) {

			scaleGestureDetector.onTouchEvent(event);

			return true;
		}

		@Override
		protected void onDraw(Canvas canvas) {

			canvas.drawRect(point.x, point.y, point.x + size, point.y + size,
					paint);

			super.onDraw(canvas);
		}

		private class ScaleListener extends
				ScaleGestureDetector.SimpleOnScaleGestureListener {
			@Override
			public boolean onScale(ScaleGestureDetector detector) {
				size *= detector.getScaleFactor();

				invalidate();
				return true;
			}

			@Override
			public boolean onScaleBegin(ScaleGestureDetector detector) {
				size *= detector.getScaleFactor();
				return true;
			}

			@Override
			public void onScaleEnd(ScaleGestureDetector detector) {
				size *= detector.getScaleFactor();
			}
		}
	}
}
