using System;
using System.Reflection;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
class Program
{
    static void MapProperties(Source source, Destination destination)
    {
        // Get the properties of the Source and Destination classes
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();

       
        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                    break;
                }
            }
        }
    }

    static void Main()
    {
        // Step 3: Test the Dynamic Property Mapping

        
        Source source = new Source { Id = 1, Name = "SourceObject" };
        Destination destination = new Destination { Id = 0, Name = "", Description = "" }; // Initialize with default values

       
        MapProperties(source, destination);

       
        Console.WriteLine("Mapped Properties in Destination:");
        Console.WriteLine($"Id: {destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Description: {destination.Description}");

        Console.ReadKey();
    }
}
