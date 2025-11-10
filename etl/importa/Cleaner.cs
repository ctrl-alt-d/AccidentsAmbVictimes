namespace importa;

public class Cleaner
{
    public void CleanDataset(List<Accident> accidents)
    {
        // Aplicar reglas de limpieza para campos numéricos
        ApplyCleaningRule(accidents,
            a => a.C_VELOCITAT_VIA,
            (a, v) => a.C_VELOCITAT_VIA = v,
            v => v == 99 || v == 999);

        ApplyCleaningRule(accidents,
            a => a.Pk,
            (a, v) => a.Pk = v,
            v => v == 9999);

        // Aplicar reglas de limpieza para campos string con 'NA'
        CleanStringField(accidents, a => a.D_REGULACIO_PRIORITAT, (a, v) => a.D_REGULACIO_PRIORITAT = v);
        CleanStringField(accidents, a => a.D_SENTITS_VIA, (a, v) => a.D_SENTITS_VIA = v);
        CleanStringField(accidents, a => a.D_SUBTIPUS_TRAM, (a, v) => a.D_SUBTIPUS_TRAM = v);
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
    /// Limpia campos string que contienen 'NA' o están vacíos
    /// </summary>
    private void CleanStringField(
        List<Accident> accidents,
        Func<Accident, string?> getter,
        Action<Accident, string?> setter)
    {
        accidents
            .Where(a => string.IsNullOrWhiteSpace(getter(a)) || getter(a) == "NA")
            .ToList()
            .ForEach(a => setter(a, null));
    }
}


