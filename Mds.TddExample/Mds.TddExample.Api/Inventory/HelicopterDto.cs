namespace Mds.TddExample.Api.Inventory
{
    public class HelicopterDto : CreateHelicopterDto
    {
        public int Id { get; set; }
    }

    public class CreateHelicopterDto
    {
        public string Name { get; set; }
    }
}
