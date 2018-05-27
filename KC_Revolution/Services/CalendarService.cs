using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Http;
using Google.Apis.Services;
using Microsoft.AspNetCore.Hosting;
using Google.Apis.Calendar.v3;

namespace DOTNETWEB_KCREVOLUTION.Areas.Connect.Models.Data.Services
{
    public class GoogleCalendarService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public CalendarService _googleCalendarService;
        public GoogleCalendarService()
        {
            var serviceAccountEmail = "kcrev-274@annular-axe-192103.iam.gserviceaccount.com";
            var path = Directory.GetCurrentDirectory() + "\\Areas\\Connect\\Models\\Data\\Services\\secret.p12";
          
            string[] scopes = new string[] { CalendarService.Scope.Calendar};

            var cert = new X509Certificate2(path, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential cred = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(cert));
                CalendarService calendarService = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = cred,
                    ApplicationName = "My Project"
                });
                _googleCalendarService = calendarService;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
            }

        }

        public List<KC_Revolution.Data.Entities.Event> GetListedEvents(CalendarService cs)
        {
            EventsResource.ListRequest request = cs.Events.List("233itgmvvfm1v857q404r6t1p4@group.calendar.google.com");
            request.MaxResults = 25;
            request.SingleEvents = true;
            Events eventRequest = request.Execute();
            var eventItems = eventRequest.Items.ToList();
            List<KC_Revolution.Data.Entities.Event> events = new List<KC_Revolution.Data.Entities.Event>();
            foreach (var ev in eventItems)
            {
                events.Add(new KC_Revolution.Data.Entities.Event()
                {
                    Id = ev.Id,
                    Title = ev.Summary,
                    Description = ev.Summary,
                    StartDateTime = ev.Start.DateTime.Value,
                    EndDateTime = ev.End.DateTime.Value
                });
            }

            Console.WriteLine(events);
            return events;
        }
    }
}
