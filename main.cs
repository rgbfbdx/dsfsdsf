using System;

class Program
{
    static void Main()
    {
        Func<string, (int R, int G, int B)> getRainbowRGB = delegate (string color)
        {
            switch (color.ToLower())
            {
                case "червоний": return (255, 0, 0);
                case "помаранчевий": return (255, 128, 0);
                case "жовтий": return (255, 255, 0);
                case "зелений": return (0, 255, 0);
                case "блакитний": return (0, 128, 255);
                case "синій": return (0, 0, 255);
                case "фіолетовий": return (128, 0, 255);
                default: return (0, 0, 0);
            }
        };

        var rgb = getRainbowRGB("синій");
        Console.WriteLine($"RGB: {rgb.R}, {rgb.G}, {rgb.B}");
    }
}



using System;

class Backpack
{
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Material { get; set; }
    public double Weight { get; set; }
    public double Capacity { get; set; }
    public double CurrentVolume { get; private set; }

    public event Action<string> OnAdd;
    public event Action<string> OnRemove;
    public event Action<string> OnChange;

    public void AddItem(string item, double volume)
    {
        if (CurrentVolume + volume > Capacity)
            throw new Exception("Перевищено обсяг рюкзака!");

        CurrentVolume += volume;
        OnAdd?.Invoke(item);
    }

    public void RemoveItem(string item, double volume)
    {
        CurrentVolume -= volume;
        if (CurrentVolume < 0) CurrentVolume = 0;

        OnRemove?.Invoke(item);
    }

    public void ChangeItem(string item, double newVolume)
    {
        if (newVolume > Capacity)
            throw new Exception("Об'єкт займає забагато місця!");

        CurrentVolume = newVolume;
        OnChange?.Invoke(item);
    }
}
