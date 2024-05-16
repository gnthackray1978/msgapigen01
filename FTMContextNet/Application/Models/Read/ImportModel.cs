using System;

namespace FTMContextNet.Application.Models.Read;

public class ImportModel
{
    public string FileName { get; set; }

    public string FileSize { get; set; }

    public int Id { get; set; }

    public DateTime DateImported { get; set; }

    public bool Selected { get; set; }

    public int UserId { get; set; }

    public DateTime? PersonsProcessed { get; set; }

    public DateTime? CCProcessed { get; set; }

    public DateTime? GeocodingProcessed { get; set; }

    public DateTime? MissingLocationsProcessed { get; set; }

    public DateTime? DupesProcessed { get; set; }

}