namespace HospitalApp.Models.Api.ListViewModels.Options;

/// <summary>
/// Настройки для сортировки по столбцу
/// </summary>
public class OrderOptions
{
    /// <summary>
    /// Имя столбца
    /// </summary>
    public string Field { get; set; }

    /// <summary>
    /// Направление по возрастанию/убыванию
    /// </summary>
    public OrderDirection Direction { get; set; }
}
