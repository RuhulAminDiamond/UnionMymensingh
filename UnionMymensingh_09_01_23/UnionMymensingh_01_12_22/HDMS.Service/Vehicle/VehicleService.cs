using HDMS.Model.Vehicle;
using HDMS.Repository.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDMS.Service.Vehicle
{
    public class VehicleService
    {
        public bool SaveCar(CarInfo carInfo)
        {
            return new VehicleRepository().SaveCar(carInfo);
        }

        public IList<CarInfo> GetCarList()
        {
            return new VehicleRepository().GetCarList();
        }

        public CarInfo GetCar(int carId)
        {
            return new VehicleRepository().GetCar( carId);
        }

        public bool UpCarInfo(CarInfo carInfo)
        {
            return new VehicleRepository().UpCarInfo( carInfo);
        }

        public bool SaveDriverInfo(DriverInfo driver)
        {
            return new VehicleRepository().SaveDriverInfo(driver);
        }

        public bool UpRouteInfo(RoutingOrTripInfo tripInfo)
        {
            return new VehicleRepository().UpRouteInfo(tripInfo);
        }

        public RoutingOrTripInfo GetRoute(int routeId)
        {
            return new VehicleRepository().GetRoute(routeId);
        }

        public bool SaveRent(RoutingOrTripInfo tripInfo)
        {
            return new VehicleRepository().SaveRent(tripInfo);
        }

        public IList<DriverInfo> GetDriverList()
        {
            return new VehicleRepository().GetDriverList();
        }

        public IList<RoutingOrTripInfo> GetRouteInfo()
        {
            return new VehicleRepository().GetRouteInfo();
        }

        public DriverInfo GetDriver(int driverId)
        {
            return new VehicleRepository().GetDriver(driverId);
        }

        public bool UpDriverInfo(DriverInfo driver)
        {
            return new VehicleRepository().UpDriverInfo(driver);
        }

        public IList<RoutingOrTripInfo> GetAllRoute()
        {
            return new VehicleRepository().GetAllRoute();
        }

        public IList<CarInfo> GetAllAvailableCar()
        {
            return new VehicleRepository().GetAllAvailableCar();
        }

       

        public IList<DriverInfo> GetAllAvailableDriver()
        {
            return new VehicleRepository().GetAllAvailableDriver();
        }

        public bool SaveAllotmentInfo(CarAllotmentInfo carAllotmentInfo)
        {
            return new VehicleRepository().SaveAllotmentInfo(carAllotmentInfo);
        }
    }
}
