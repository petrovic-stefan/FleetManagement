namespace Desktop;

public static class EventHub
{
    public static event Action? VehiclesChanged;
    public static event Action? DriversChanged;

    public static void RaiseVehiclesChanged() => VehiclesChanged?.Invoke();
    public static void RaiseDriversChanged() => DriversChanged?.Invoke();
}