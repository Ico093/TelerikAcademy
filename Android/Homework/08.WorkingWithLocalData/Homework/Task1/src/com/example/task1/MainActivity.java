package com.example.task1;

import java.util.List;
import java.util.Random;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class MainActivity extends Activity {

	private CommentsDataSource datasource;
	
	private ListView listView;
	private ArrayAdapter<Comment> adapter;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		listView=(ListView)this.findViewById(R.id.list);

		datasource = new CommentsDataSource(this);
		datasource.open();

		List<Comment> values = datasource.getAllComments();

		// use the SimpleCursorAdapter to show the
		// elements in a ListView
		adapter = new ArrayAdapter<Comment>(this,
				android.R.layout.simple_list_item_1, values);
		
		listView.setAdapter(adapter);
	}

	// Will be called via the onClick attribute
	// of the buttons in main.xml
	public void onClick(View view) {
		@SuppressWarnings("unchecked")
		Comment comment = null;
		switch (view.getId()) {
		case R.id.add:
			String[] comments = new String[] { "Cool", "Very nice", "Hate it" };
			int nextInt = new Random().nextInt(3);
			// save the new comment to the database
			comment = datasource.createComment(comments[nextInt]);
			adapter.add(comment);
			break;
		case R.id.delete:
			if (adapter.getCount() > 0) {
				comment = (Comment) adapter.getItem(0);
				datasource.deleteComment(comment);
				adapter.remove(comment);
			}
			break;
		}
		adapter.notifyDataSetChanged();
	}

	@Override
	protected void onResume() {
		datasource.open();
		super.onResume();
	}

	@Override
	protected void onPause() {
		datasource.close();
		super.onPause();
	}
}
