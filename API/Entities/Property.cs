using System.Collections.Generic;

public class Property
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public string Type { get; set; }
    public PropertyParameters PropertyParameters { get; set; } 

    public Property()
    {
        Address = new Address();
    }
}

public class Land : Property
{
    public double Area { get; set; }
}

public class Building : Property
{
    public int NumFloors { get; set; }
}

public class House : Building
{
    public int NumBedrooms { get; set; }
    public BalconyType Balcony { get; set; }
    public ParkingType Parking { get; set; }
    public HotWaterType HotWater { get; set; }
    public HeatingType Heating { get; set; }
}

public class Hotel : Building
{
    public int NumRooms { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}

public class PropertyParameters
{
    public int Id { get; set; }
    public Property Property { get; set; } 
}

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
