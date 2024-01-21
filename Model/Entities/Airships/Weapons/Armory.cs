using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Model.Entities.Airships.Weapons;

[Table("SHIP_HAS_WEAPONS_JT")]
public class Armory
{
    [Column("WEAPON_ID")]
    public int WeaponId { get; set; }
    public AWeapon Weapon { get; set; }
    
    
    [Column("SHIP_ID")]
    public int AirshipId { get; set; }
    public Airship Airship { get; set; }


    [Column("POSITION")]
    [Required, Range(1,21)]
    public int Position { get; set; }
    
    [StringLength(30), Required]
    [Column("DAMAGE_STATE")]
    public EDamageState DamageState { get; set; }
}