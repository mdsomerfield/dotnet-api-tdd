using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Api.Domains.Helicopters
{
    public record CreateHelicopterDto
    {
        public string Name { get; set; }
    }

    public record HelicopterDto : CreateHelicopterDto
    {
        public int Id { get; set; }
    }
}
