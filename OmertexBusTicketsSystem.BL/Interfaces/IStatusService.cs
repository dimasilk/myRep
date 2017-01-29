using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmertexBusTicketsSystem.BL.DTO;

namespace OmertexBusTicketsSystem.BL.Interfaces
{
    public interface IStatusService
    {
        StatusDto GetStatusById(int id);
        void DeleteStatus(int statusId);
        void UpdateStatus(StatusDto statusModelDto);
        void AddStatus(StatusDto statusModelDto);
    }
}
