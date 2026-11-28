using ConstructionApp.Shared;
using Microsoft.AspNetCore.SignalR;

namespace ConstructionAppServer
{
    public class ProgressUpdateService
    {
        private readonly DatabaseManager Dbmanager;
        private readonly IHubContext<NotificationHub> HubContext;

        public ProgressUpdateService(DatabaseManager dbManager,IHubContext<NotificationHub> hubContext)
        {
            Dbmanager = dbManager;
            HubContext = hubContext;
        }
        public async Task SubmitUpdateAsync(SubmitUpdateDTO dto, int workerId)
        {
            // Verify worker is assigned to site
            if (!Dbmanager.IsWorkerAssigned(workerId, dto.SiteID))
            {
                throw new UnauthorizedAccessException(
                    "Worker is not assigned to this site.");
            }

            // Verify phase belongs to site
            if (!Dbmanager.IsPhaseInSite(dto.PhaseID, dto.SiteID))
            {
                throw new Exception("Invalid phase.");
            }

            // Retrieve assigned contractor's UserID
            int contractorUserId =Dbmanager.GetContractorUserId(dto.SiteID);

            // Create progress update

            ProgressUpdate update = new ProgressUpdate();

            update.site = _dbManager.GetSiteById(dto.SiteID);
            update.worker = _dbManager.GetWorkerById(workerId);
            update.Description = dto.Description;
            update.DateSubmitted = DateTime.UtcNow;
            update.Status = "Pending";
            // Save update and photo
            int updateId = Dbmanager.AddProgressUpdate(update);

            await Dbmanager.SavePhotoAsync(dto.Photo, updateId);

            // Notify assigned contractor
            await HubContext.Clients
                .User(contractorUserId.ToString())
                .SendAsync("ReceiveNotification",
                    "A worker has submitted a new progress update.");
        }
    }
}
