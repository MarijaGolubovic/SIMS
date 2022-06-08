using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    internal class DaysOffRequestStorage : IDaysOffRequestStorage
    {
        private readonly Serialization.Serializer<DaysOffRequest> daysOffRequestSerializer;
        public DaysOffRequestStorage()
        {
            daysOffRequestSerializer = new Serialization.Serializer<DaysOffRequest>();
        }
        public List<DaysOffRequest> GetAll()
        {
            return daysOffRequestSerializer.fromCSV("daysOfRequirements.txt");
        }

        public DaysOffRequest GetOne(int requestId)
        {
            DaysOffRequest request = new DaysOffRequest();

            foreach (DaysOffRequest req in GetAll())
            {
                if (req.RequestId.Equals(requestId))
                {
                    request = req;
                    break;
                }
            }
            return request;
        }

        public void Create(DaysOffRequest request)
        {
            List<DaysOffRequest> requirements = GetAll();
            requirements.Add(request);
            daysOffRequestSerializer.toCSV("daysOfRequirements.txt", requirements);
        }

        public Boolean Update(DaysOffRequest daysOffRequest)
        {
            List<DaysOffRequest> daysOffRequests = GetAll();
            Serialization.Serializer<DaysOffRequest> serializer = new Serialization.Serializer<DaysOffRequest>();
            daysOffRequests.Remove(daysOffRequests.Find(d => d.RequestId.Equals(daysOffRequest.RequestId)));
            daysOffRequests.Add(daysOffRequest);
            serializer.toCSV("daysOfRequirements.txt", daysOffRequests);
            return true;
        }
    }
}
