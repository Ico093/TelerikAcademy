package com.example.task2;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

public class CustomGridViewAdapter extends ArrayAdapter<String> {

	static class ViewHolderItem {
		ImageView imageView;
		TextView bigTextView;
		TextView smallTextView;
	}

	private Context context;
	private int[] images;
	
	public CustomGridViewAdapter(Context context, int resource,int[] images) {
		super(context, resource);

		this.context = context;
		this.images = images;
	}

	@Override
	public View getView(int position, View view, ViewGroup parent) {
		
		ViewHolderItem holderItem;
		
		if (view == null) {
			holderItem=new ViewHolderItem();
			LayoutInflater inflater = (LayoutInflater) context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			view = inflater.inflate(R.layout.custom_grid_view_adapter, parent,
					false);
			
			holderItem.imageView=(ImageView) view.findViewById(R.id.mainImageView);
			holderItem.bigTextView=(TextView) view.findViewById(R.id.bigTextView);
			holderItem.smallTextView=(TextView) view.findViewById(R.id.smallTextView);
			
			view.setTag(holderItem);
		}
		else {
			holderItem=(ViewHolderItem) view.getTag();
		}

		holderItem.imageView.setImageResource(this.images[position]);
		holderItem.bigTextView.setText(this.getItem(position));
		holderItem.smallTextView.setText(this.getItem(position));

		return view;
	}
}
