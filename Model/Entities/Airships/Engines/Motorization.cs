using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Airships.Engines;

[Table("AIRSHIP_HAS_ENGINES_JT")]
public class Motorization
{
    [Column("ENGINE_ID")]
    public int EngineId { get; set; }
    public Engine Engine { get; set; }

    [Column("AIRSHIP_ID")]
    public int AirshipId { get; set; }
    public Airship Airship { get; set; }
}