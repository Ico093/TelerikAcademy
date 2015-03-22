package com.example.task1;

import android.os.Parcel;
import android.os.Parcelable;

public class Product implements Parcelable {
	private String name;
	private String category;
	private Integer id;
	private Integer quantity;
	private Double price;
	
	public Product(String name, String category, Integer id, Integer quantity, Double price)
	{
		this.name=name;
		this.category=category;
		this.id=id;
		this.quantity=quantity;
		this.price=price;
	}
	
	public Product(Parcel in){
		String[] data = new String[5];

        in.readStringArray(data);
		
		this.name=data[0];
		this.category=data[1];
		this.id=Integer.parseInt(data[2]) ;
		this.quantity=Integer.parseInt(data[3]);
		this.price=Double.parseDouble(data[3]);
	}
	
	public String getName()
	{
		return this.name;
	}
	
	public String getCategory()
	{
		return this.category;
	}
	
	public Integer getId()
	{
		return this.id;
	}
	
	public Integer getQuantity()
	{
		return this.quantity;
	}
	
	public Double getPrice()
	{
		return this.price;
	}

	@Override
	public int describeContents() {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public void writeToParcel(Parcel dest, int flags) {
		dest.writeStringArray(new String[] {this.name,
							                this.category,
							                this.id.toString(),
							                this.quantity.toString(),
							                this.price.toString()});
	}
	
	public static final Parcelable.Creator CREATOR = new Parcelable.Creator() {
        public Product createFromParcel(Parcel in) {
            return new Product(in); 
        }

        public Product[] newArray(int size) {
            return new Product[size];
        }
    };
}
