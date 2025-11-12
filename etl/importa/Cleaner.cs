namespace importa;

public class Cleaner
{
    private static readonly string[] ValorsInvalids = ["Sense especificar", "Sense Especificar", "NA"];

    public void CleanDataset(List<Accident> accidents)
    {
        // Aplicar reglas de limpieza para campos numéricos
        ApplyCleaningRule(accidents,
            a => a.C_VELOCITAT_VIA,
            (a, v) => a.C_VELOCITAT_VIA = v,
            v => v == 0 || v == 99 || v == 999);

        ApplyCleaningRule(accidents,
            a => a.Pk,
            (a, v) => a.Pk = v,
            v => v == 9999);

        // Aplicar limpieza para campos string con valores inválidos
        CleanStringField(accidents, a => a.D_ACC_AMB_FUGA, (a, v) => a.D_ACC_AMB_FUGA = v);
        CleanStringField(accidents, a => a.D_BOIRA, (a, v) => a.D_BOIRA = v);
        CleanStringField(accidents, a => a.D_CARACT_ENTORN, (a, v) => a.D_CARACT_ENTORN = v);
        CleanStringField(accidents, a => a.D_CARRIL_ESPECIAL, (a, v) => a.D_CARRIL_ESPECIAL = v);
        CleanStringField(accidents, a => a.D_CIRCULACIO_MESURES_ESP, (a, v) => a.D_CIRCULACIO_MESURES_ESP = v);
        CleanStringField(accidents, a => a.D_CLIMATOLOGIA, (a, v) => a.D_CLIMATOLOGIA = v);
        CleanStringField(accidents, a => a.D_FUNC_ESP_VIA, (a, v) => a.D_FUNC_ESP_VIA = v);
        CleanStringField(accidents, a => a.D_GRAVETAT, (a, v) => a.D_GRAVETAT = v);
        CleanStringField(accidents, a => a.D_INFLUIT_BOIRA, (a, v) => a.D_INFLUIT_BOIRA = v);
        CleanStringField(accidents, a => a.D_INFLUIT_CARACT_ENTORN, (a, v) => a.D_INFLUIT_CARACT_ENTORN = v);
        CleanStringField(accidents, a => a.D_INFLUIT_CIRCULACIO, (a, v) => a.D_INFLUIT_CIRCULACIO = v);
        CleanStringField(accidents, a => a.D_INFLUIT_ESTAT_CLIMA, (a, v) => a.D_INFLUIT_ESTAT_CLIMA = v);
        CleanStringField(accidents, a => a.D_INFLUIT_INTEN_VENT, (a, v) => a.D_INFLUIT_INTEN_VENT = v);
        CleanStringField(accidents, a => a.D_INFLUIT_LLUMINOSITAT, (a, v) => a.D_INFLUIT_LLUMINOSITAT = v);
        CleanStringField(accidents, a => a.D_INFLUIT_MESU_ESP, (a, v) => a.D_INFLUIT_MESU_ESP = v);
        CleanStringField(accidents, a => a.D_INFLUIT_OBJ_CALCADA, (a, v) => a.D_INFLUIT_OBJ_CALCADA = v);
        CleanStringField(accidents, a => a.D_INFLUIT_SOLCS_RASES, (a, v) => a.D_INFLUIT_SOLCS_RASES = v);
        CleanStringField(accidents, a => a.D_INFLUIT_VISIBILITAT, (a, v) => a.D_INFLUIT_VISIBILITAT = v);
        CleanStringField(accidents, a => a.D_INTER_SECCIO, (a, v) => a.D_INTER_SECCIO = v);
        CleanStringField(accidents, a => a.D_LIMIT_VELOCITAT, (a, v) => a.D_LIMIT_VELOCITAT = v);
        CleanStringField(accidents, a => a.D_LLUMINOSITAT, (a, v) => a.D_LLUMINOSITAT = v);
        CleanStringField(accidents, a => a.D_REGULACIO_PRIORITAT, (a, v) => a.D_REGULACIO_PRIORITAT = v);
        CleanStringField(accidents, a => a.D_SENTITS_VIA, (a, v) => a.D_SENTITS_VIA = v);
        CleanStringField(accidents, a => a.D_SUBTIPUS_ACCIDENT, (a, v) => a.D_SUBTIPUS_ACCIDENT = v);
        CleanStringField(accidents, a => a.D_SUBTIPUS_TRAM, (a, v) => a.D_SUBTIPUS_TRAM = v);
        CleanStringField(accidents, a => a.D_SUBZONA, (a, v) => a.D_SUBZONA = v);
        CleanStringField(accidents, a => a.D_SUPERFICIE, (a, v) => a.D_SUPERFICIE = v);
        CleanStringField(accidents, a => a.D_TIPUS_VIA, (a, v) => a.D_TIPUS_VIA = v);
        CleanStringField(accidents, a => a.D_TITULARITAT_VIA, (a, v) => a.D_TITULARITAT_VIA = v);
        CleanStringField(accidents, a => a.D_TRACAT_ALTIMETRIC, (a, v) => a.D_TRACAT_ALTIMETRIC = v);
    }

    /// <summary>
    /// Aplica una regla de limpieza genérica para campos nullable
    /// </summary>
    private void ApplyCleaningRule<T>(
        List<Accident> accidents,
        Func<Accident, T?> getter,
        Action<Accident, T?> setter,
        Func<T?, bool> shouldClean) where T : struct
    {
        accidents
            .Where(a => shouldClean(getter(a)))
            .ToList()
            .ForEach(a => setter(a, null));
    }

    /// <summary>
    /// Limpia campos string que contienen valores inválidos o están vacíos
    /// </summary>
    private void CleanStringField(
        List<Accident> accidents,
        Func<Accident, string?> getter,
        Action<Accident, string?> setter)
    {
        accidents
            .Where(a => string.IsNullOrWhiteSpace(getter(a)) || ValorsInvalids.Contains(getter(a)))
            .ToList()
            .ForEach(a => setter(a, null));
    }
}


