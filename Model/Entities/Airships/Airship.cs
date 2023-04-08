using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entities.Airships.Engines;
using Model.Entities.Airships.Weapons;

namespace Model.Entities.Airships;

[Table("AIRSHIPS")]
public class Airship {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("AIRSHIP_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }

    [Required, Range(0,100)]
    [Column("AIRSHIP_SPEED")]
    public int Speed { get; set; }

    [Required, Range(0, 500)]
    [Column("HULL_POINTS")]
    public int HullPoints { get; set; }

    [Required, Range(0, 6)]
    [Column("ARMOR_VALUE")]
    public int ArmorValue { get; set; }

    [Required]
    [Column("DAMAGE_STATE")]
    public EDamageState DamageState { get; set; }

    public List<Motorization> MotorizationList { get; set; } = new List<Motorization>();
    public List<Armory> ArmoryList { get; set; } = new List<Armory>();
}