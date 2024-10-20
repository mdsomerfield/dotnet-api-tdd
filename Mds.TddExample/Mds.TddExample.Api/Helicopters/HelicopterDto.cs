using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Api.Helicopters
{
    public class CreateHelicopterDto
    {
        public string Name { get; set; }
    }

    public class HelicopterDto : CreateHelicopterDto
    {
        public int Id { get; set; }
    }
}
