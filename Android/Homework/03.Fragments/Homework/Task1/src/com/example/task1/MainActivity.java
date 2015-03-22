package com.example.task1;

import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Context;
import android.opengl.Visibility;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;
import android.widget.TextView;

public class MainActivity extends Activity {

	private final Context context = this;
	private ListView listView;
	private CustomAdapter adapter;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		listView = (ListView) this.findViewById(R.id.listView1);
		
		adapter = new CustomAdapter(context, R.layout.listview_custom);
		adapter.add(new Product("Morena", "Hrana", 2, 22, 0.40));
		adapter.add(new Product("Hiper", "Hrana", 23, 232, 0.45));
		adapter.add(new Product("Tryben kliuch", "Instrumenti", 21, 2, 240.0));

		listView.setAdapter(adapter);

		listView.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				Bundle bundle = new Bundle();
				bundle.putParcelable("product", adapter.getItem(position));
				
				Fragment fragment = new FragmentDialog();
				fragment.setArguments(bundle);
				FragmentManager fragmentManager = getFragmentManager();
				FragmentTransaction fragmentTransaction = fragmentManager
						.beginTransaction();
				fragmentTransaction.replace(R.id.detailscontainer, fragment);
				fragmentTransaction.commit();
			}
		});
	}

	
}
