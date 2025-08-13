using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace DoctorManagementPanelApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IDeviceService _deviceService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public SignalRHub(IDeviceService deviceService, IDoctorService doctorService, IPatientService patientService)
        {
            _deviceService = deviceService;
            _doctorService = doctorService;
            _patientService = patientService;
        }
        public async Task SendStatistic()
        {
            var value = _deviceService.TGetDeviceWithLastMeasurements();
            await Clients.All.SendAsync("ReceiveGetDeviceWithLastMeasurements", value);

        }
        public async Task SendStatistic2(int id)
        {
            var value = _deviceService.TGetDeviceWithLastMeasurementsByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithLastMeasurementsByDeviceID", value);

            var value2 = _deviceService.TGetDeviceWithAveragePulseByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithAveragePulseByDeviceID", value2);

            var value3 = _deviceService.TGetDeviceWithAverageSpO2ByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithAverageSpO2ByDeviceID", value3);

            var value4 = _deviceService.TGetDeviceWithHighestPulseByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithHighestPulseByDeviceID", value4);

            var value5 = _deviceService.TGetDeviceWithLowestPulseByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithLowestPulseByDeviceID", value5);
        }
        public async Task SendStatistic3(int id)
        {

            var value = _deviceService.TGetDeviceWithHighestPulsePatientByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithHighestPulsePatientByDeviceID", value);

            var value2 = _deviceService.TGetDeviceWithLowestPulsePatientByDeviceID(id);
            await Clients.All.SendAsync("ReceiveGetDeviceWithLowestPulsePatientByDeviceID", value2);

            var value3 = _doctorService.TDoctorCountByIsStatusTrue();
            await Clients.All.SendAsync("ReceiveDoctorCountByIsStatusTrue", value3);

            var value4 = _patientService.TPatientCountByStatusTrue();
            await Clients.All.SendAsync("ReceivePatientCountByStatusTrue", value4);
        }
    }
}
