using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConfigHelper;
using FTMContextNet.Data.Repositories.GedImports;
using MSGIdent;
using FTMContextNet.Domain.Commands;
using LoggingLib;
using MSG.CommonTypes;
using MediatR;
using FTMContextNet.Data.Repositories.GedProcessing;
using FTMContextNet.Data.Repositories.TreeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace FTMContextNet.Application.UserServices.CreatePersonsAndRelationships
{
    public class CreatePersonsAndRelationships : IRequestHandler<CreatePersonAndRelationshipsCommand, CommandResult>
    {
       //private static readonly SemaphoreSlim RateLimit = new SemaphoreSlim(1, 1);
        private readonly IPersistedCacheRepository _persistedCacheRepository;
        private readonly IPersistedImportCacheRepository _persistedImportCacheRepository;
        private readonly IGedRepository _gedRepository;
        private readonly Ilog _ilog;
        private readonly IAuth _auth;
        private readonly IMSGConfigHelper _iMSGConfigHelper;
        private int _currentImportId;
        private int _currentUserId;

        public CreatePersonsAndRelationships(IPersistedCacheRepository persistedCacheRepository,
            IPersistedImportCacheRepository persistedImportCacheRepository,
            IGedRepository gedRepository,
            IAuth auth,
            Ilog outputHandler,
            IMSGConfigHelper iMSGConfigHelper)
        {
            _persistedCacheRepository = persistedCacheRepository;
            _persistedImportCacheRepository = persistedImportCacheRepository;
            _gedRepository = gedRepository;
            _ilog = outputHandler;
            _auth = auth;
            _iMSGConfigHelper = iMSGConfigHelper;
        }
          
        public async Task<CommandResult> Handle(CreatePersonAndRelationshipsCommand request, CancellationToken cancellationToken)
        {
            if (_auth.GetUser() == -1)
            {
                return CommandResult.Fail(CommandResultType.Unauthorized);
            }

            _currentImportId = _persistedImportCacheRepository.GetCurrentImportId();

            if (IsTreeImported())
            {
                return CommandResult.Fail(CommandResultType.RecordExists);
            }

            //check if tree has been imported already if so then abort.

            _ilog.WriteLine("Creating Persons and Relationships", 2);

           
            _currentUserId = _auth.GetUser();


            await AddTreeRecord(cancellationToken);

            AddTreeMetaData();

            await AddGroups(cancellationToken);

            _persistedImportCacheRepository.SetPersonsProcessed(_currentImportId);

            return CommandResult.Success();
        }

        private bool IsTreeImported()
        {
            return _persistedCacheRepository.ImportPresent(_currentImportId);
        }

        private async Task AddTreeRecord(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                string path = Path.Combine(_iMSGConfigHelper.GedPath, _persistedImportCacheRepository.GedFileName());

                _ilog.WriteLine("Parsing Tree", 2);

                var gedDb = _gedRepository.ParseLabelledTree(path, _persistedCacheRepository.LastId()+1);
                
                _ilog.WriteLine("Adding Person Details", 2);

                _persistedCacheRepository.InsertPersons(_currentImportId, _currentUserId, gedDb.Persons);

                _ilog.WriteLine("Adding Relationships", 2);

                //var p1 = gedDb.Persons.FirstOrDefault(w => w.FamilyName == "Douglas" && w.Forename == "John");

                //var p2 = gedDb.Persons.FirstOrDefault(w => w.FamilyName == "Luck" && w.Forename == "Ann");

                //var r1 = gedDb.Relationships.Where(w => w.Person1Id == p1.Id || w.Person2Id == p1.Id).ToList();


                _persistedCacheRepository.InsertRelationships(_currentImportId, _currentUserId, gedDb.Relationships);

                _ilog.WriteLine("Adding Person Tree Origins", 2);

                _persistedCacheRepository.CreatePersonOriginEntries(_currentImportId, _currentUserId);

                
            }, cancellationToken);
        }

        private async Task AddGroups(CancellationToken cancellationToken)
        {
            var groupPersons = _persistedCacheRepository.GetGroupPerson(_currentImportId);

            var groups = _persistedCacheRepository.GetGroups(_currentImportId);

            await Task.Run(() =>
            {
                _ilog.WriteLine("Adding Tree Groups", 2);

                _persistedCacheRepository.InsertTreeGroups(groupPersons, _currentImportId, _currentUserId);

                _ilog.WriteLine("Adding Tree Group Mappings", 2);

                _persistedCacheRepository.InsertTreeRecordMapGroup(groups, _currentImportId, _currentUserId);

                _ilog.WriteLine("Finished Create Tree Group Mappings",2);

            }, cancellationToken);
        }

        private void AddTreeMetaData()
        {
            _ilog.WriteLine("Creating Tree Records",2);

            _persistedCacheRepository.PopulateTreeRecordFromCache(_currentUserId, _currentImportId);
        }
    }
}
