using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PropertyParametersEntity
{
    [Key]
    public int Id { get; set; }

    // Parameters
    public double YardArea { get; set; }
    public double TotalArea { get; set; }
    public int NumFloors { get; set; }
    public int NumRooms { get; set; }
    public int NumBedrooms { get; set; }
    public bool WetPoint { get; set; }
    public bool AcceptableSpace { get; set; }
    public double LoggiaSpace { get; set; }
    public double BalconySpace { get; set; }
    public double PorchSpace { get; set; }
    public double StorageRoomSpace { get; set; }
    public bool Parking { get; set; }
    public string HotWater { get; set; }
    public string Heating { get; set; }
    public bool Fireplace { get; set; }
    public bool Cellar { get; set; }
    public bool Pool { get; set; }
    public bool NaturalGas { get; set; }
    public bool Alarm { get; set; }
    public bool Internet { get; set; }
    public bool Water { get; set; }
    public bool Sewage { get; set; }
    public bool Electricity { get; set; }
    public bool Television { get; set; }

    // Foreign key to Property
    public int PropertyId { get; set; }

    // Navigation property to Property
    [ForeignKey("PropertyId")]
    public Property Property { get; set; }

    // Enum definitions
    public enum BalconyType
    {
        Close,
        Open
    }

    public enum ParkingType
    {
        YardParking,
        Garage
    }

    public enum HotWaterType
    {
        GasHeaterTank,
        ElectricHeaterTank
    }

    public enum HeatingType
    {
        CentralHeating,
        GasHeater,
        PowerHeater
    }
}
