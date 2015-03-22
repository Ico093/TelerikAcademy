package com.example.task2;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.GridView;
import android.widget.Toast;

public class MainActivity extends Activity {

	private final Context context = this;
	private GridView gridView;
	private ArrayList<String> dataArrayList;
	private CustomGridViewAdapter adapter;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		adapter = new CustomGridViewAdapter(context,
				R.layout.custom_grid_view_adapter,
				new int[] { R.drawable.ic_launcher,R.drawable.ic_launcher });

		adapter.add("Kalinki");

		gridView = (GridView) this.findViewById(R.id.mainGridView);
		gridView.setAdapter(adapter);

		gridView.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {

				adapter.add("Novoto");
				adapter.notifyDataSetChanged();
				Toast.makeText(context,
						String.valueOf(adapter.getItem(position)),
						Toast.LENGTH_SHORT).show();

			}

		});
	}
}
