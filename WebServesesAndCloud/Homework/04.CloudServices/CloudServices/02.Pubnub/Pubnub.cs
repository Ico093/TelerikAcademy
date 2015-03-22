using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class Pubnub
{
	static void Main()
	{
		PubnubAPI pubnub = new PubnubAPI(
            "pub-c-1776bd27-f356-4f36-9b86-b0cb4798a8e3",               // PUBLISH_KEY
            "sub-c-9c0ac472-e7b9-11e3-a91c-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-OWY4ZDA0NmYtNmEzNi00NDA4LWI4YmYtNTIyOTU2MTMzZWUz",   // SECRET_KEY
			true                                                        // SSL_ON?
		);
		string channel = "IcoPubnub";

		// Publish a sample message to Pubnub
		List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
		Console.WriteLine(
			"Publish Success: " + publishResult[0].ToString() + "\n" +
			"Publish Info: " + publishResult[1]
		);

		// Show PubNub server time
		object serverTime = pubnub.Time();
		Console.WriteLine("Server Time: " + serverTime.ToString());

		// Subscribe for receiving messages (in a background task to avoid blocking)
		System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
			() =>
			pubnub.Subscribe(
				channel,
				delegate(object message)
				{
					Console.WriteLine("Received Message -> '" + message + "'");
					return true;
				}
			)
		);
		t.Start();

		// Read messages from the console and publish them to Pubnub
		while (true)
		{
			string msg = Console.ReadLine();
			pubnub.Publish(channel, msg);
		}
	}
}