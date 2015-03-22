package com.example.task1;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class FragmentDialog extends Fragment {

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {

		View v = inflater.inflate(R.layout.fragment_dialog, container, false);
		Bundle arguments = getArguments();

		if (arguments != null) {
			Product recievedData = (Product) arguments.get("product");
			setData(v, recievedData);
		}
		return v;
	}

	private void setData(View v, Product product) {
		((TextView) v.findViewById(R.id.textViewDialogName)).setText(product
				.getName());
		((TextView) v.findViewById(R.id.textViewDialogCategory)).setText(product
				.getCategory());
		((TextView) v.findViewById(R.id.textViewDialogId)).setText(product
				.getId().toString());
		((TextView) v.findViewById(R.id.textViewDialogQuantity))
				.setText(product.getQuantity().toString());
		((TextView) v.findViewById(R.id.textViewDialogPrice)).setText(product
				.getPrice().toString());
	}
}
