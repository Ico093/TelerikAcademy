package com.example.task1;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CustomAdapter extends ArrayAdapter<Product>{

	static class ViewHolder {
		TextView name;
		TextView category;
	}

	private Context context;

	public CustomAdapter(Context context, int resource) {
		super(context, resource);
		this.context = context;
	}

	@Override
	public View getView(int position, View view, ViewGroup parent) {

		ViewHolder holderItem;

		if (view == null) {
			holderItem = new ViewHolder();

			LayoutInflater inflater = (LayoutInflater) context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.listview_custom, parent,
					false);

			holderItem.name = (TextView) view
					.findViewById(R.id.textViewName);
			holderItem.category = (TextView) view
					.findViewById(R.id.textViewCategory);
			
			view.setTag(holderItem);
		} else {
			holderItem = (ViewHolder) view.getTag();
		}

		holderItem.name.setText(this.getItem(position).getName());
		holderItem.category.setText(this.getItem(position).getCategory());
		return view;
	}
}
