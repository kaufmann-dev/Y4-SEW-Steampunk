using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Airships.Weapons; 

[Table("WEAPONS_ST")]
public class AWeapon {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("WEAPON_ID")]
    public int Id { get; set; }

    [Required, StringLength(100)]
    [Column("NAME")]
    public string Name { get; set; }
    
    [Required, Range(0, 6)]
    [Column("ATTACK_VALUE")]
    public int AttackValue { get; set; }

    [Required, Range(0, 5000)]
    [Column("AMMONITION_CAPACITY")]
    public int AmmonitionCapacity { get; set; }
    

    [Required]
    [Column("RANGE")]
    public ERangeType Range { get; set; }

}