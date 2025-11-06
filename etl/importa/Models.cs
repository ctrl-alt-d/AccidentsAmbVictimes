/*
Any,zona,dat,via,pk,nomMun,nomCom,nomDem,F_MORTS,F_FERITS_GREUS,F_FERITS_LLEUS,F_VICTIMES,F_UNITATS_IMPLICADES,F_VIANANTS_IMPLICADES,F_BICICLETES_IMPLICADES,F_CICLOMOTORS_IMPLICADES,F_MOTOCICLETES_IMPLICADES,F_VEH_LLEUGERS_IMPLICADES,F_VEH_PESANTS_IMPLICADES,F_ALTRES_UNIT_IMPLICADES,F_UNIT_DESC_IMPLICADES,C_VELOCITAT_VIA,D_ACC_AMB_FUGA,D_BOIRA,D_CARACT_ENTORN,D_CARRIL_ESPECIAL,D_CIRCULACIO_MESURES_ESP,D_CLIMATOLOGIA,D_FUNC_ESP_VIA,D_GRAVETAT,D_INFLUIT_BOIRA,D_INFLUIT_CARACT_ENTORN,D_INFLUIT_CIRCULACIO,D_INFLUIT_ESTAT_CLIMA,D_INFLUIT_INTEN_VENT,D_INFLUIT_LLUMINOSITAT,D_INFLUIT_MESU_ESP,D_INFLUIT_OBJ_CALCADA,D_INFLUIT_SOLCS_RASES,D_INFLUIT_VISIBILITAT,D_INTER_SECCIO,D_LIMIT_VELOCITAT,D_LLUMINOSITAT,D_REGULACIO_PRIORITAT,D_SENTITS_VIA,D_SUBTIPUS_ACCIDENT,D_SUBTIPUS_TRAM,D_SUBZONA,D_SUPERFICIE,D_TIPUS_VIA,D_TITULARITAT_VIA,D_TRACAT_ALTIMETRIC,D_VENT,grupDiaLab,hor,grupHor,tipAcc,tipDia
2010,Zona urbana,25/01/2010,SE,999999,Cànoves i Samalús,Vallès Oriental,Barcelona,0,1,0,1,2,0,0,0,0,1,0,1,0,100,No,No n'hi ha,Desmunt,No n'hi ha,No n'hi ha,Bon temps,Sense funció especial,Accident greu,No,No,No,No,No,No,No,No,No,No,Arribant o eixint intersecció fins 50m,Genérica via,"De nit, il·luminació artificial suficient",Sols norma prioritat de pas,Un sol sentit,Encalç,Intersecció en T o Y,Zona urbana,Sec i net,Via urbana( inclou carrer i carrer residencial),NA,NA,"Calma, vent molt suau",Feiners,23.33,Nit,Col.lisió de vehicles en marxa,dill-dij
2010,Carretera,31/10/2010,N-240,"99,9",Lleida,Segrià,Lleida,0,1,3,4,1,0,0,0,0,1,0,0,0,40,No,No n'hi ha,A nivell,No n'hi ha,No n'hi ha,Bon temps,Sense funció especial,Accident greu,No,No,No,No,No,No,No,No,No,No,Dintre intersecció,Senyal velocitat,"De nit, il·luminació artificial suficient",Senyal Stop o cedeix pas,Doble sentit,Resta sortides de via,Giratòria,Carretera,Sec i net,Carretera convencional,Estatal,Pla,"Calma, vent molt suau",CapDeSetmana,1,Nit,Sortida de la calcada sense especificar,dg
2010,Carretera,17/05/2010,N-II,"708,7",Fornells de la Selva,Gironès,Girona,1,0,2,3,4,0,0,0,0,2,2,0,0,80,No,No n'hi ha,A nivell,No n'hi ha,No n'hi ha,Bon temps,Variant,Accident mortal,No,No,No,No,No,No,No,No,No,No,En secció,Senyal velocitat,"De dia, dia clar",NA,Doble sentit,Col·lisió frontal,NA,Carretera,Sec i net,Carretera convencional,Estatal,Rampa o pendent,"Calma, vent molt suau",Feiners,15.27,Tarda,Col.lisió de vehicles en marxa,dill-dij
2010,Zona urbana,21/08/2010,SE,999999,Barcelona,Barcelonès,Barcelona,0,2,7,9,2,0,0,0,0,2,0,0,0,100,No,No n'hi ha,Sense Especificar,No n'hi ha,No n'hi ha,Bon temps,Sense funció especial,Accident greu,No,No,No,No,No,No,No,No,No,No,Dintre intersecció,Genérica via,"De nit, il·luminació artificial suficient",Semàfor,Un sol sentit,Envestida (frontal lateral),Encreuament o intersecció en X o +,Zona urbana,Sec i net,Via urbana( inclou carrer i carrer residencial),NA,NA,"Calma, vent molt suau",CapDeSetmana,22.3,Nit,Col.lisió de vehicles en marxa,dis
2010,Zona urbana,07/05/2010,SE,999999,Badalona,Barcelonès,Barcelona,0,1,0,1,1,0,0,0,1,0,0,0,0,100,No,No n'hi ha,Sense Especificar,No n'hi ha,No n'hi ha,Bon temps,Sense funció especial,Accident greu,No,No,No,No,No,No,No,No,No,No,Dintre intersecció,Genérica via,"De dia, dia clar",Sols norma prioritat de pas,Un sol sentit,Caiguda en la via,Encreuament o intersecció en X o +,Zona urbana,Sec i net,Via urbana( inclou carrer i carrer residencial),NA,NA,"Calma, vent molt suau",CapDeSetmana,17.45,Tarda,Bolcada a la calcada,div
2010,Carretera,16/08/2010,SE,999999,Sant Carles de la Ràpita,Montsià,Tarragona,0,1,1,2,2,0,0,1,0,1,0,0,0,40,No,No n'hi ha,Mixt,No n'hi ha,No n'hi ha,Bon temps,Sense funció especial,Accident greu,No,No,No,No,No,No,No,No,No,No,Dintre intersecció,Senyal velocitat,"De dia, dia clar",Senyal Stop o cedeix pas,Doble sentit,Encalç,Intersecció en T o Y,Carretera,Sec i net,Altres,Municipal,Rampa o pendent,"Calma, vent molt suau",Feiners,14.57,Tarda,Col.lisió de vehicles en marxa,dill-dij
*/


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace importa;

// El modelo y las columnas se mapearán en minúscula en la base de datos
[Table("accidents")]
public class Accident
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    [Column("any")]
    public int Any { get; set; }
    [Column("zona")]
    public string Zona { get; set; } = string.Empty;
    [Column("dat")]
    public DateTime Dat { get; set; }
    [Column("via")]
    public string Via { get; set; } = string.Empty;
    [Column("pk")]
    public decimal? Pk { get; set; }
    [Column("nommun")]
    public string NomMun { get; set; } = string.Empty;
    [Column("nomcom")]
    public string NomCom { get; set; } = string.Empty;
    [Column("nomdem")]
    public string NomDem { get; set; } = string.Empty;
    [Column("f_morts")]
    public int F_MORTS { get; set; }
    [Column("f_ferits_greus")]
    public int F_FERITS_GREUS { get; set; }
    [Column("f_ferits_lleus")]
    public int F_FERITS_LLEUS { get; set; }
    [Column("f_victimes")]
    public int F_VICTIMES { get; set; }
    [Column("f_unitats_implicades")]
    public int F_UNITATS_IMPLICADES { get; set; }
    [Column("f_vianants_implicades")]
    public int F_VIANANTS_IMPLICADES { get; set; }
    [Column("f_bicicletes_implicades")]
    public int F_BICICLETES_IMPLICADES { get; set; }
    [Column("f_ciclomotors_implicades")]
    public int F_CICLOMOTORS_IMPLICADES { get; set; }
    [Column("f_motocicletes_implicades")]
    public int F_MOTOCICLETES_IMPLICADES { get; set; }
    [Column("f_veh_lleugers_implicades")]
    public int F_VEH_LLEUGERS_IMPLICADES { get; set; }
    [Column("f_veh_pesants_implicades")]
    public int F_VEH_PESANTS_IMPLICADES { get; set; }
    [Column("f_altres_unit_implicades")]
    public int F_ALTRES_UNIT_IMPLICADES { get; set; }
    [Column("f_unit_desc_implicades")]
    public int F_UNIT_DESC_IMPLICADES { get; set; }
    [Column("c_velocitat_via")]
    public int? C_VELOCITAT_VIA { get; set; }
    [Column("d_acc_amb_fuga")]
    public string D_ACC_AMB_FUGA { get; set; } = string.Empty;
    [Column("d_boira")]
    public string D_BOIRA { get; set; } = string.Empty;
    [Column("d_caract_entorn")]
    public string D_CARACT_ENTORN { get; set; } = string.Empty;
    [Column("d_carril_especial")]
    public string D_CARRIL_ESPECIAL { get; set; } = string.Empty;
    [Column("d_circulacio_mesures_esp")]
    public string D_CIRCULACIO_MESURES_ESP { get; set; } = string.Empty;
    [Column("d_climatologia")]
    public string D_CLIMATOLOGIA { get; set; } = string.Empty;
    [Column("d_func_esp_via")]
    public string D_FUNC_ESP_VIA { get; set; } = string.Empty;
    [Column("d_gravetat")]
    public string D_GRAVETAT { get; set; } = string.Empty;
    [Column("d_influit_boira")]
    public string D_INFLUIT_BOIRA { get; set; } = string.Empty;
    [Column("d_influit_caract_entorn")]
    public string D_INFLUIT_CARACT_ENTORN { get; set; } = string.Empty;
    [Column("d_influit_circulacio")]
    public string D_INFLUIT_CIRCULACIO { get; set; } = string.Empty;
    [Column("d_influit_estat_clima")]
    public string D_INFLUIT_ESTAT_CLIMA { get; set; } = string.Empty;
    [Column("d_influit_inten_vent")]
    public string D_INFLUIT_INTEN_VENT { get; set; } = string.Empty;
    [Column("d_influit_lluminositat")]
    public string D_INFLUIT_LLUMINOSITAT { get; set; } = string.Empty;
    [Column("d_influit_mesu_esp")]
    public string D_INFLUIT_MESU_ESP { get; set; } = string.Empty;
    [Column("d_influit_obj_calcada")]
    public string D_INFLUIT_OBJ_CALCADA { get; set; } = string.Empty;
    [Column("d_influit_solcs_rases")]
    public string D_INFLUIT_SOLCS_RASES { get; set; } = string.Empty;
    [Column("d_influit_visibilitat")]
    public string D_INFLUIT_VISIBILITAT { get; set; } = string.Empty;
    [Column("d_inter_seccio")]
    public string D_INTER_SECCIO { get; set; } = string.Empty;
    [Column("d_limit_velocitat")]
    public string D_LIMIT_VELOCITAT { get; set; } = string.Empty;
    [Column("d_lluminositat")]
    public string D_LLUMINOSITAT { get; set; } = string.Empty;
    [Column("d_regulacio_prioritat")]
    public string D_REGULACIO_PRIORITAT { get; set; } = string.Empty;
    [Column("d_sentits_via")]
    public string D_SENTITS_VIA { get; set; } = string.Empty;
    [Column("d_subtipus_accident")]
    public string D_SUBTIPUS_ACCIDENT { get; set; } = string.Empty;
    [Column("d_subtipus_tram")]
    public string D_SUBTIPUS_TRAM { get; set; } = string.Empty;
    [Column("d_subzona")]
    public string D_SUBZONA { get; set; } = string.Empty;
    [Column("d_superficie")]
    public string D_SUPERFICIE { get; set; } = string.Empty;
    [Column("d_tipus_via")]
    public string D_TIPUS_VIA { get; set; } = string.Empty;
    [Column("d_titularitat_via")]
    public string D_TITULARITAT_VIA { get; set; } = string.Empty;
    [Column("d_tracat_altimetric")]
    public string D_TRACAT_ALTIMETRIC { get; set; } = string.Empty;
    [Column("d_vent")]
    public string D_VENT { get; set; } = string.Empty;
    [Column("grupdialab")]
    public string GrupDiaLab { get; set; } = string.Empty;
    [Column("hor")]
    public string Hor { get; set; } = string.Empty;
    [Column("gruphor")]
    public string GrupHor { get; set; } = string.Empty;
    [Column("tipacc")]
    public string TipAcc { get; set; } = string.Empty;
    [Column("tipdia")]
    public string TipDia { get; set; } = string.Empty;
}