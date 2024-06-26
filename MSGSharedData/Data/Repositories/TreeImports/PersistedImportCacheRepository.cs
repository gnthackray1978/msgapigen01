﻿using System;
using System.Collections.Generic;
using System.Linq;
using FTMContextNet.Domain.Entities.NonPersistent;
using FTMContextNet.Domain.Entities.Persistent.Cache;
using LoggingLib;

namespace FTMContextNet.Data.Repositories.GedImports;

public class PersistedImportCacheRepository : IPersistedImportCacheRepository
{
    private readonly IPersistedCacheContext _persistedCacheContext;
    private readonly Ilog _iLog;

    public PersistedImportCacheRepository(IPersistedCacheContext persistedCacheContext, Ilog iLog)
    {
        _persistedCacheContext = persistedCacheContext;
        _iLog = iLog;
    }



    public void DeleteImport(int importId)
    {
        _persistedCacheContext.DeleteImports(importId);
    }
    
    public bool ImportExists(string fileName, string fileSize, int userId)
    {
        return _persistedCacheContext.TreeImport.Any(a => a.FileSize == fileSize && a.FileName == fileName && a.UserId == userId);
    }

    public bool ImportExists(int importId)
    {
        return _persistedCacheContext.TreeImport.Any(a => a.Id == importId);
    }

    public string SelectImport(int importId, int userId)
    {
        foreach (var imp in _persistedCacheContext.TreeImport.Where(w => w.UserId == userId))
        {
            imp.Selected = false;
        }

        _persistedCacheContext.TreeImport.First(f => f.Id == importId).Selected = true;

        _persistedCacheContext.SaveChanges();
        
        return "";
    }
      
    public string SetDupesProcessed(int importId)
    {
        _persistedCacheContext.TreeImport.First(f => f.Id == importId).DupesProcessed = DateTime.Today;

        _persistedCacheContext.SaveChanges();
        return "";
    }
    public string SetPersonsProcessed(int importId)
    {
        _persistedCacheContext.TreeImport.First(f => f.Id == importId).PersonsProcessed = DateTime.Today;

        _persistedCacheContext.SaveChanges();
        return "";
    }
    public string SetMissingLocationsProcessed(int importId)
    {
        _persistedCacheContext.TreeImport.First(f => f.Id == importId).MissingLocationsProcessed = DateTime.Today;

        _persistedCacheContext.SaveChanges();
        return "";
    }
    public string SetGeocodingProcessed(int importId)
    {
        _persistedCacheContext.TreeImport.First(f => f.Id == importId).GeocodingProcessed = DateTime.Today;

        _persistedCacheContext.SaveChanges();
        return "";
    }
    public string SetCCProcessed(int importId)
    {
        _persistedCacheContext.TreeImport.First(f => f.Id == importId).CCProcessed = DateTime.Today;

        _persistedCacheContext.SaveChanges();
        return "";
    }


    public List<TreeImport> GetImportData()
    {
        return _persistedCacheContext.TreeImport.ToList();
    }

    public List<TreeImport> GetImportData(bool selectedOnly)
    {
        if(!selectedOnly)
            return _persistedCacheContext.TreeImport.ToList();

        return _persistedCacheContext.TreeImport.Where(w=>w.Selected).ToList();
    }

    public string GedFileName()
    {
        var path = _persistedCacheContext.TreeImport.FirstOrDefault(f => f.Selected)?.FileName ?? "";

        return path;
    }

    public ImportData AddImportRecord(string fileName, string fileSize, bool selected, int userId)
    {
        // if there has been a previous import with this filename 
        // we want to overwrite it. 

        var importData = new ImportData() { CurrentId = new List<int>() };

        int newId = 1;

        if (_persistedCacheContext.TreeImport.Any())
        {
            importData.CurrentId = _persistedCacheContext
                .TreeImport.Where(w => w.FileName == fileName)
                .Select(s => s.Id).ToList();

            newId = _persistedCacheContext.TreeImport.Max(m => m.Id) + 1;
        }


        var import = new TreeImport()
        {
            Id = newId,
            FileName = fileName,
            FileSize = fileSize,
            DateImported = DateTime.Today.ToShortDateString() + " " + DateTime.Today.ToShortTimeString(),
            Selected = selected,
            UserId = userId
        };

        _persistedCacheContext.TreeImport.Add(import);

        _persistedCacheContext.SaveChanges();

        importData.NextId = newId;

        return importData;
    }

    public int GetCurrentImportId()
    {
        return _persistedCacheContext.TreeImport.FirstOrDefault(f => f.Selected)?.Id ?? -1;
    }
}