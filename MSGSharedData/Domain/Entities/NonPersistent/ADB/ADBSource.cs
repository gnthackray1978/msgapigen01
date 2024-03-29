﻿namespace MSGSharedData.Domain.Entities.NonPersistent.ADB;

public class ADBSource
{
    public int Id { get; set; }
    public string SourceRef { get; set; }
    public int SourceDate { get; set; }
    public int SourceDateTo { get; set; }
    public string SourceDateStr { get; set; }
    public string SourceDateStrTo { get; set; }
    public string SourceDescription { get; set; }
    public string OriginalLocation { get; set; }
    public bool IsCopyHeld { get; set; }
    public bool IsViewed { get; set; }
    public bool IsThackrayFound { get; set; }
    public DateTime DateAdded { get; set; }
    public int UserId { get; set; }
    public string SourceNotes { get; set; }
    public int SourceFileCount { get; set; }
}