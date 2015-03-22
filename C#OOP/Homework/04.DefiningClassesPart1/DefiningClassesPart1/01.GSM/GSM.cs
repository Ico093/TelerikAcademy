using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public enum BatteryTypes
{
    Lilon, NiMH, NiCd
}

class GSM
{
    private string model;
    private string manifacturer;
    private double price;
    private string owner;
    private Battery battery;
    private Display display;
    private List<Call> callHistory = new List<Call>();
    const decimal priceOfCall = 0.37M;
    static private GSM iPhone4S = new GSM("iPhone 4S", "Apple", 900, "Hristo", BatteryTypes.Lilon, 120, 16, 3.5, 512000);

    public string Model
    {
        get { return model; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Model name can't be empty.");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Model name is too short. At least 3 letters.");
            }
            else if (value.Length > 50)
            {
                throw new ArgumentException("Model name is too long. At most 50 letters.");
            }
            else
            {
                model = value;
            }
        }
    }

    public string Manifacturer
    {
        get { return manifacturer; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Manifacturer name can't be empty.");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Manifacturer name is too short. At least 3 letters.");
            }
            else if (value.Length > 50)
            {
                throw new ArgumentException("Manifacturer name is too long. At most 50 letters.");
            }
            else
            {
                manifacturer = value;
            }
        }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Price can't be negative.");
            }
            else
            {
                price = value;
            }
        }
    }

    public string Owner
    {
        get { return owner; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Owner name can't be empty.");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException("Owner name is too short. At least 3 letters.");
            }
            else if (value.Length > 50)
            {
                throw new ArgumentException("Owner name is too long. At most 50 letters.");
            }
            else
            {
                owner = value;
            }
        }
    }

    public Battery myBattery
    {
        get { return battery; }
        set { battery = value; }
    }

    public Display myDisplay
    {
        get { return display; }
        set { display = value; }
    }

    public List<Call> CallHistory
    {
        get { return callHistory; }
    }

    public static GSM IPhone4S
    {
        get { return iPhone4S; }
    }

    public GSM(string model) : this(model, string.Empty, 0, string.Empty, BatteryTypes.Lilon, 0, 0, 0, 0) { }

    public GSM(string model, string manifacturer, double price, string owner, BatteryTypes batteryType, decimal batteryHoursIdle, decimal batteryHoursTalk, double displaySize, long displayColors)
    {
        this.Model = model;
        this.Manifacturer = manifacturer;
        this.Price = price;
        this.Owner = owner;
        this.myBattery = new Battery(batteryType, batteryHoursIdle, batteryHoursTalk);
        this.myDisplay = new Display(displaySize, displayColors);
    }

    public override string ToString()
    {
        return "\n" + "GSM Model:" + model + "\nManifacturer:" + manifacturer + "\nPrice:" + price + "\nOwner:" + owner + display.ToString() + battery.ToString();
    }

    public void AddCall(Call call)
    {
        callHistory.Add(call);
    }

    public void DeleteCall(Call call)
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i] == call)
            {
                callHistory.Remove(callHistory[i]);
                break;
            }
        }
    }

    public void ClearCallHistory()
    {
        callHistory.Clear();
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0M;

        for (int i = 0; i < callHistory.Count; i++)
        {
            totalPrice += (decimal)((callHistory[i].Duration / 60) * priceOfCall);
        }

        return totalPrice;
    }
}