using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Property
{
   public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public string Type { get; set; }

    public PropertyParametersEntity PropertyParameters { get; set; }

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
    public PropertyBalconyType Balcony { get; set; }
    public PropertyParkingType Parking { get; set; }
    public PropertyHotWaterType HotWater { get; set; }
    public PropertyHeatingType Heating { get; set; }
}

public class Hotel : Building
{
    public int NumRooms { get; set; }
}

public class Address
{
[Key]
    public int Id { get; set; }

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

public enum PropertyBalconyType
{
    Close,
    Open
}

public enum PropertyParkingType
{
    YardParking,
    Garage
}

public enum PropertyHotWaterType
{
    GasHeaterTank,
    ElectricHeaterTank
}

public enum PropertyHeatingType
{
    CentralHeating,
    GasHeater,
    PowerHeater
}
