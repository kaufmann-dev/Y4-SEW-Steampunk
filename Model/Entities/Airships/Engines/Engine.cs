using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Airships.Engines; 

[Table("ENGINES_ST")]
public class Engine {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ENGINE_ID")]
    public int Id { get; set; }
    
    [Required, StringLength(100)]
    [Column("ENGINE_LABEL")]
    public string Label { get; set; }
    
    [Required]
    [Column("POWER_TYPE")]
    public EPowerType PowerType { get; set; }


}