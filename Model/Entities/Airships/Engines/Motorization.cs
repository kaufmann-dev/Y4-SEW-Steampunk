using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Airships.Engines;

[Table("AIRSHIP_HAS_ENGINES_JT")]
public class Motorization
{
    [Column("ENGINE_ID")]
    public int EngineId { get; set; }
    public AEngine AEngine { get; set; }

    [Column("AIRSHIP_ID")]
    public int AirshipId { get; set; }
    public Airship Airship { get; set; }
    
    [Required, Range(1,21)]
    [Column("POSITION")]
    public int Position { get; set; }
    
    [StringLength(30), Required]
    [Column("DAMAGE_STATE")]
    public EDamageState DamageState { get; set; }
}