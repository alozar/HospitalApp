namespace HospitalApp.Models.Api.ListViewModels.Options;

/// <summary>
/// Порядок сортировки
/// </summary>
public enum OrderDirection
{
    /// <summary>
    /// Без сортировки
    /// </summary>
    None = 0,

    /// <summary>
    /// По возрастанию
    /// </summary>
    Asc,

    /// <summary>
    /// По убыванию
    /// </summary>
    Desc
}
